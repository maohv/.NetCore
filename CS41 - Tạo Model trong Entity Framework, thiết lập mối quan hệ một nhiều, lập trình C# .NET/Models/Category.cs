using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName = "ntext")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        //Dieu huong tap hop (Collect Navigation)
        public virtual List<Product> Products { get; set; } //Thêm virtual để tự động nạp với optionsBuilder.UseLazyLoadingProxies();
    }
}