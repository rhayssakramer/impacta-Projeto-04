using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace impacta_Projeto04.Models
{
    public class Tarefa
    {
        public int TarefaID { get; set; }
        [Required]
        public string? Nome { get; set; }
        public string? Status { get; set; }
     
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataConclusao { get; set; }
    }
}