using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS43___Migration_v__Scaffold_trong_Entity_Framework
{
    public class ArticleTag
    {
        [Key]
        public int ArticleTagId { set; get; }
        public int TagId { set; get; } //Fk

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        public int ArticleId { set; get; } //Fk

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

    }
}