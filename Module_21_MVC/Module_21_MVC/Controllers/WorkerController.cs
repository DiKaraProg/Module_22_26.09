using Microsoft.AspNetCore.Mvc;
using Module_21_MVC.Dal.Interfaces;
using Module_21_MVC.Service.Interfaces;
using Module_21_MVC_Domain.ViewModels.Worker;

namespace Module_21_MVC.Controllers
{
    public class WorkerController : Controller
    {
        public readonly IWorkerService workerService;
        public WorkerController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetWorkers()
        {
            var worker = await workerService.GetAllWorkers();
            if (worker.Data!=null)
            {
                return View(worker.Data.ToList());
            }
            return RedirectToAction("WorkerNull");
        }

        [HttpGet]
        public async Task<IActionResult> GetWorker(int id)
        {
            if (id== 0)
            {
                return View(null);
            }
            var workers = await workerService.GetWorker(id);
            return View(workers.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var worker = await workerService.Delete(id);
            if (worker.Data)
            {
                return RedirectToAction("GetWorkers");
            }
            return RedirectToAction("GetWorkers");
        }
        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id ==0)
            {
                return View();
            }
            var worker = await workerService.GetWorker(id);
            return View(worker.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Save (WorkerViewModel model)
        {
            if (model.Id==0)
            {
                await workerService.CreateWorker(model);
            }
            else
            {
                await workerService.Edit(model.Id,model);
            }
            return RedirectToAction("GetWorkers");
        }
        [HttpGet]
        public IActionResult AddWorker()
        {
            return View();
        }
        public async Task<IActionResult> ChangeWorker(int id)
        {
            var worker = await workerService.GetWorker(id);
                return View(worker.Data);
        }
        public IActionResult WorkerNull()
        {
            ViewBag.text = "Работников нет";
            return View(null);
        }
    }
}
