using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio_1.Models
{  
    [Table("Atendimento")]
    public class Atendimento
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int alunoID { get; set; }
        [ForeignKey("alunoID")]
        public Aluno aluno { get; set; }
        [Required]
        public int salaID { get; set; }
        [ForeignKey("salaID")]
        public Sala sala { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime data { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime hora { get; set; }
    }
}
