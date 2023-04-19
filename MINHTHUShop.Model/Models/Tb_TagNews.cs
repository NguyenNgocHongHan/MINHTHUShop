using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_TagNews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagNewsID { get; set; }

        [Required]
        public int TagID { get; set; }

        [Required]
        public int NewsID { get; set; }

        [ForeignKey("TagID")]
        public virtual Tb_Tag Tb_Tag { get; set; }
        [ForeignKey("NewsID")]
        public virtual Tb_News Tb_News { get; set; }
    }
}