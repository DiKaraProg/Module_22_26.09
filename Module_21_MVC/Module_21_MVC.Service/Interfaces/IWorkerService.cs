using Module_21_MVC_Domain.Entity;
using Module_21_MVC_Domain.Response;
using Module_21_MVC_Domain.ViewModels.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC.Service.Interfaces
{
    public interface IWorkerService
    {
        Task<IBaseResponse<IEnumerable<Worker>>> GetAllWorkers();

        Task<IBaseResponse<WorkerViewModel>> CreateWorker(WorkerViewModel workerViewModel);
        Task<IBaseResponse<bool>> Delete(int id);

        Task<IBaseResponse<Worker>> GetByName(string name);

        Task<IBaseResponse<WorkerViewModel>> GetWorker(int Id);
        Task<IBaseResponse<Worker>> Edit(int id,WorkerViewModel model);
    }
}
