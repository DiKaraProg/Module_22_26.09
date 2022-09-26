using Microsoft.AspNetCore.Mvc;
using Module_21_MVC.Service.Interfaces;
using Module_21_MVC_Domain.Entity;
using Module_21_MVC_Domain.ViewModels.Worker;

namespace Module_22_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        public readonly IWorkerService workerService;
        public WorkerController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }

        [HttpGet]
        public async Task<IEnumerable<Worker>> GetWorkers()
        {
            var worker = await workerService.GetAllWorkers();

            return worker.Data.ToList();


        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<WorkerViewModel> GetWorker(int id)
        {

            var workers = await workerService.GetWorker(id);
            return workers.Data;
        }

        [HttpDelete]
        [Route("Delete")]
        public async void Delete(int id)
        {
            var worker = await workerService.Delete(id);
           
        }

        [HttpPost]
        [Route("ADD")]
        public async void Add([FromBody]WorkerViewModel model)
        {
            
           await workerService.CreateWorker(model);

        }
        [HttpPost]
        [Route("Edit")]
        public async void Edit([FromBody] WorkerViewModel model)
        {

          
                await workerService.Edit(model.Id, model);
            
        }
    }
}
