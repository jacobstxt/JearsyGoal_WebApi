using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Search
{
    public class SearchResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public PaginationModel Pagination { get; set; } = new PaginationModel();
    }
}
