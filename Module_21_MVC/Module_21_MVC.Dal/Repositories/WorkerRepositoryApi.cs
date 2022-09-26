using Microsoft.EntityFrameworkCore;
using Module_21_MVC.Dal.Interfaces;
using Module_21_MVC_Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC.Dal.Repositories
{
    public class WorkerRepositoryApi : IBaseRepository<Worker>
    {
        private HttpClient httpClient { get; set; }

        public WorkerRepositoryApi(ApplicationDbContext dbContext)
        {
            httpClient = new HttpClient();
        }
        public async Task<List<Worker>> Select()
        {
            string url = @"https://localhost:44351/api/Worker";

            string json =  httpClient.GetStringAsync(url).Result;

            return  JsonConvert.DeserializeObject<List<Worker>>(json);
        }

        public async Task<bool> Create(Worker entity)
        {
            string url = @$"https://localhost:44351/api/Worker/ADD";
            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8,
                mediaType:"application/json")
                ).Result;
            return true;
        }

        public async Task<Worker> Get(int id)
        {
            string url =  $@"https://localhost:44351/api/Worker/GetById/{id}";

            var json =  httpClient.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<Worker>(json);
        }

        public async Task<bool> Delete(Worker entity)
        {
            string url = @$"https://localhost:44351/api/Worker/Delete";
            var r =  httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
            return true;
        }

        public Task<Worker> Update(Worker entity)
        {
            throw new NotImplementedException();
        }

        public Task<Worker> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
