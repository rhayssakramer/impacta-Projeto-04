using System.ComponentModel.DataAnnotations;

namespace impacta_Projeto04.Models
{
    public class Tarefa
    {
        [Display(Name = "ID")]
        public int TarefaID { get; set; }

        [Display(Name = "Tarefa")]
        public string? Nome { get; set; }

        [Display(Name = "Status")]
        public string? Status { get; set; }

        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; } = DateTime.Now;

        [Display(Name = "Data de Conclusão")]
        public DateTime? DataConclusao { get; set; }
    }
}