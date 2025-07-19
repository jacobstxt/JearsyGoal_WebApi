using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models.General;
using Domain.Entities.Delivery;

namespace Core.Mapper
{
    public class DeliveryMapper: Profile
    {
        public DeliveryMapper()
        {
            CreateMap<CityEntity, SimpleModel>();
            CreateMap<PostDepartmentEntity, SimpleModel>();
            CreateMap<PaymentTypeEntity, SimpleModel>();
        }
    }
}
