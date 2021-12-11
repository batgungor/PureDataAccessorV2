using PureDataAccessor.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PureDataAccessor.Examples.EntityFrameworkCore.Entities
{
    [Table("Categories")]
    public class CategoryEntity : PDAEFBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
