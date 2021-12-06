using PureDataAccessor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PureDataAccessor.Examples.EntityFrameworkCore.Entities
{
    [Table("Products")]
    public class ProductEntity : PDABaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
