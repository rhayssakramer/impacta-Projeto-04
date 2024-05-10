using impacta_Projeto04.Models;
using Microsoft.AspNetCore.Mvc;

namespace impacta_Projeto04.Controllers
{
    public class TarefaController : Controller
    {
        private static List<Tarefa> _tarefas = new List<Tarefa>()
        {
            new Tarefa { TarefaID = 1, Nome = "Tarefa 1", Status = "Iniciar", DataInicio = DateTime.Now },
            new Tarefa { TarefaID = 2, Nome = "Tarefa 2", Status = "Iniciar", DataInicio = DateTime.Now },
            new Tarefa { TarefaID = 3, Nome = "Tarefa 3", Status = "Concluido", DataInicio = DateTime.Now.AddDays(-3), DataConclusao = DateTime.Now }

        };

        public IActionResult Index()
        {
            return View(_tarefas);
        }

        //CREATE
        [HttpGet]
        public IActionResult Create() 
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (!ModelState.IsValid)
            {
                tarefa.TarefaID = _tarefas.Count() > 0 ? _tarefas.Max(t => t.TarefaID + 1) : 1;
                _tarefas.Add(tarefa);
            }
            return RedirectToAction("Index");
        }

        //READ
        public IActionResult Details() 
        { 
            return View(); 
        }

        //EDIT
        public IActionResult Edit(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaID == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa) 
        {
            if (!ModelState.IsValid) 
            { 
                var TarefaExistente = _tarefas.FirstOrDefault(t => t.TarefaID == tarefa.TarefaID);
                if (TarefaExistente != null) 
                {
                    TarefaExistente.Nome = tarefa.Nome;
                    TarefaExistente.Status = tarefa.Status;
                    TarefaExistente.DataInicio = tarefa.DataInicio;
                    TarefaExistente.DataConclusao = tarefa.DataConclusao;
                }
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        //DELET
        public IActionResult Delete(int id) 
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delet")]
        public IActionResult Delet(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaID == id);
            if(tarefa == null)
            {
                return NotFound();
            }
            _tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }
    }
}
