using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINHTHUShop.Model.Abstract
{
    public class Tb_About : SEO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AboutID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "char(10)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Fanpage { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        public string Description { get; set; }

        public bool? Status { get; set; } = true;
    }
}
