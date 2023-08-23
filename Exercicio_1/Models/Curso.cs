using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio_1.Models
{
    [Table("Curso")]
    public class Curso
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(30)]
        public string descricao { get; set; }
    }
}
