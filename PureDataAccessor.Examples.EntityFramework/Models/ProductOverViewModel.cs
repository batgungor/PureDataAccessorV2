using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PureDataAccessor.Examples.EntityFrameworkCore.Models
{
    public class ProductOverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategoryModel Category { get; set; }

        public class ProductCategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
