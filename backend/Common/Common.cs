using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luxelane.Common
{

    public class ProductQueryOptions
    {
        public SortByProduct SortByProduct { get; set; } 
        public string Search { get; set; } = string.Empty;
        public OrderByProduct OrderByProduct { get; set; }
        public int Limit { get; set; } = 30;
        public int Skip { get; set; } = 0;
    }

    public enum OrderByProduct
    {
        ASC,
        DESC
    }

    public enum SortByProduct
    {
        Name,
        Description,
        Price,
        Quantity
    }

}