using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Interfaces;
using Core.Models.Account;
using Core.Models.Search;
using Core.Models.Search.Params;
using Domain;
using Domain.Entitties.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class UserService(
        UserManager<UserEntity> userManager,
        IMapper mapper,
        IImageService imageService,
        IConfiguration configuration,
        AppDbJerseyGoalContext jerseyContext) : IUserService
    {

        public async Task<List<UserItemModel>> List()
        {
            var model = await mapper.ProjectTo<UserItemModel>(jerseyContext.Users).ToListAsync();
            await jerseyContext.UserLogins.ForEachAsync(login =>
            {
                var user = model.FirstOrDefault(u => u.Id == login.UserId);
                if (user != null)
                {
                    user.LoginTypes.Add(login.LoginProvider);
                }
            });

            await jerseyContext.Users.ForEachAsync(dbUser =>
            {
                var user = model.FirstOrDefault(u => u.Id == dbUser.Id);
                if (user != null && !string.IsNullOrEmpty(dbUser.PasswordHash))
                {
                    user.LoginTypes.Add("Password");
                }
            });

            return model;
        }

        public async Task<SearchResult<UserItemModel>> SearchUsersAsync(UserSearchModel model)
        {
            var query = userManager.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                string nameFilter = model.Name.Trim().ToLower().Normalize();

                query = query.Where(u =>
                    (u.FirstName + " " + u.LastName).ToLower().Contains(nameFilter) ||
                    u.FirstName.ToLower().Contains(nameFilter) ||
                    u.LastName.ToLower().Contains(nameFilter));
            }

            if (model?.StartDate != null)
            {
                query = query.Where(u => u.DateCreated >= model.StartDate);
            }

            if (model?.EndDate != null)
            {
                query = query.Where(u => u.DateCreated <= model.EndDate);
            }

            if (model.Roles != null && model.Roles.Any())
            {
                var validRoles = model.Roles.Where(role => role != null);

                if (validRoles != null && validRoles.Count() > 0)
                {
                    var usersInRole = (await Task.WhenAll(
                        model.Roles.Select(role => userManager.GetUsersInRoleAsync(role))
                    )).SelectMany(u => u).ToList();

                    var userIds = usersInRole.Select(u => u.Id).ToHashSet();

                    query = query.Where(u => userIds.Contains(u.Id));
                }
            }

            var totalCount = await query.CountAsync();

            var safeItemsPerPage = model.ItemPerPAge < 1 ? 10 : model.ItemPerPAge;
            var totalPages = (int)Math.Ceiling(totalCount / (double)safeItemsPerPage);
            var safePage = Math.Min(Math.Max(1, model.Page), Math.Max(1, totalPages));

            var users = await query
                .OrderBy(u => u.Id)
                .Skip((safePage - 1) * safeItemsPerPage)
                .Take(safeItemsPerPage)
                .ProjectTo<UserItemModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            await LoadLoginsAndRolesAsync(users);

            return new SearchResult<UserItemModel>
            {
                Items = users,
                Pagination = new PaginationModel
                {
                    TotalCount = totalCount,
                    TotalPages = totalPages,
                    ItemsPerPage = safeItemsPerPage,
                    CurrentPage = safePage
                }
            };
        }

        private async Task LoadLoginsAndRolesAsync(List<UserItemModel> users)
        {
            await jerseyContext.UserLogins.ForEachAsync(login =>
            {
                var user = users.FirstOrDefault(u => u.Id == login.UserId);
                if (user != null)
                {
                    user.LoginTypes.Add(login.LoginProvider);
                }
            });

            var identityUsers = await userManager.Users.AsNoTracking().ToListAsync();

            foreach (var identityUser in identityUsers) // Забрав foreachAsync через конфлікнт з userManager.GetRolesAsync(identityUser)
            {
                var adminUser = users.FirstOrDefault(u => u.Id == identityUser.Id);
                if (adminUser != null)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);
                    adminUser.Roles = roles.ToList();

                    if (!string.IsNullOrEmpty(identityUser.PasswordHash))
                    {
                        adminUser.LoginTypes.Add("Password");
                    }
                }
            }
        }




    }
}
