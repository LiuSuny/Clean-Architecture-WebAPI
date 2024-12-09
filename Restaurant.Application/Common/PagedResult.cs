using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Common
{
    /// <summary>
    /// this class will contain all the result and count 
    /// of page paination to end user
    /// </summary>
    public class PagedResult<T>
    {

        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsCount { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }

        public PagedResult(IEnumerable<T> items, int totalCount, int pageSize, int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            ItemsFrom = pageSize * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + pageSize - 1;
        }
    }
}
