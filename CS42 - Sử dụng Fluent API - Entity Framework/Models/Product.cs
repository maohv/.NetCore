using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]

        [Column(TypeName = "ntext")]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CateId { get; set; }

        // Foreign key
        [ForeignKey("CateId")]
        public virtual Category Category { get; set; } //FK tham chiếu đến khóa chính PK
        public void PrintInfo() => Console.WriteLine($"{ProductId} - {Name} - {Price}");
    }

}

/*
    Table("TableName);
    [Key] -> Primary (PK)
    [Required] -> not null
    [StringLength(50)] -> string -> nvachar
    [Column(TypeName = "ntext")]
    [ForeignKey("")]

    Reference Navigation = > ForeignKey (1 - nhieu)
    Collect Navigation = > (Khong tao FK)

*/