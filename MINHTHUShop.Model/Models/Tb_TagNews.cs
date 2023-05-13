using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINHTHUShop.Model.Models
{
    public class Tb_TagNews
    {
        [Key]
        [Column(Order = 1)]
        public int NewsID { get; set; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { get; set; }

        [ForeignKey("NewsID")]
        public virtual Tb_News Tb_News { get; set; }
        [ForeignKey("TagID")]
        public virtual Tb_Tag Tb_Tag { get; set; }
    }
}