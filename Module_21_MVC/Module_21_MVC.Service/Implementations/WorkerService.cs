using Module_21_MVC.Dal.Interfaces;
using Module_21_MVC.Service.Interfaces;
using Module_21_MVC_Domain.Entity;
using Module_21_MVC_Domain.Response;
using Module_21_MVC_Domain.Unum;
using Module_21_MVC_Domain.ViewModels.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC.Service.Implementations
{
    public class WorkerService : IWorkerService
    {
        private readonly IBaseRepository<Worker> workerRepository;
        public WorkerService(IBaseRepository<Worker> workerRepository)
        {
            this.workerRepository = workerRepository;
        }

        public async Task<IBaseResponse<WorkerViewModel>> CreateWorker(WorkerViewModel workerViewModel)
        {
            var baseResponse = new BaseResponse<WorkerViewModel>();
            var worker = new Worker()
            {
                Name = workerViewModel.Name,
                LastName = workerViewModel.LastName,
                FatherName = workerViewModel.FatherName,
                PhoneNumber = workerViewModel.PhoneNumber,
                Address = workerViewModel.Address,
                Note = workerViewModel.Note
            };
            await workerRepository.Create(worker);
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            var worker = await workerRepository.Get(id);
            if (worker!=null)
            {
                await workerRepository.Delete(worker);
                baseResponse.StatuseCode = StatusCode.OK;
                return baseResponse;
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<Worker>> GetByName(string name)
        {
            var baseResponse = new BaseResponse<Worker>();
            var worker = await workerRepository.GetByName(name);
            return baseResponse;
        }
        public async Task<IBaseResponse<WorkerViewModel>> GetWorker(int Id)
        {
            var baseResponse = new BaseResponse<WorkerViewModel>();
             var worker = await workerRepository.Get(Id);
            var data = new WorkerViewModel()
            {
                Id = Id,
                Name= worker.Name,
                LastName = worker.LastName,
                FatherName= worker.FatherName,
                PhoneNumber = worker.PhoneNumber, 
                Address= worker.Address,
                Note= worker.Note
            };
            baseResponse.Data = data;
            baseResponse.StatuseCode = StatusCode.OK;
            return baseResponse;
        }
        public async Task<IBaseResponse<IEnumerable<Worker>>> GetAllWorkers()
        {
            var baseresponse = new BaseResponse<IEnumerable<Worker>>();
            try
            {
                int id = 0;
                var workers = await workerRepository.Select();
                if (workers.Count == 0)
                {
                    baseresponse.Description = "Найдено 0 елементов";
                    baseresponse.StatuseCode = StatusCode.OK;
                    return baseresponse;
                }
                baseresponse.Data = workers;
                baseresponse.StatuseCode = StatusCode.OK;
                return baseresponse;

            }
            catch (Exception ex)
            {

                return new BaseResponse<IEnumerable<Worker>>()
                {
                    Description = $"[GetCars]: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Worker>> Edit(int id, WorkerViewModel model)
        
        {
            var baseResponse = new BaseResponse<Worker>();

            var worker = await workerRepository.Get(id);

            worker.PhoneNumber = model.PhoneNumber;
            worker.Name = model.Name;
            worker.Address = model.Address;
            worker.LastName = model.LastName;
            worker.Note = model.Note;
            worker.FatherName = model.FatherName;

            await workerRepository.Update(worker);
            return baseResponse;

        }
    }
}
