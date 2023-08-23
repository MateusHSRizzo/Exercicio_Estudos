using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio_1.Models
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(35)]
        public string nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime aniversario { get; set; }
        [Required]
        public int cursoID { get; set; }
        [ForeignKey("cursoID")]
        public Curso curso { get; set; }
        [Required]
        public string periodo { get; set; }
    }
}
