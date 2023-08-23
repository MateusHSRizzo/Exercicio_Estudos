using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio_1.Models
{
    [Table("Sala")]
    public class Sala
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string descricao { get; set; }
        public int equipamentos { get; set; }
        public char situacao { get; set; }
    }
}
