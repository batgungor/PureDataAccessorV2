using PureDataAccessor.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace PureDataAccessor.Examples.EntityFrameworkCore.Entities
{
    [Table("Products")]
    public class ProductEntity : PDAEFBaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
