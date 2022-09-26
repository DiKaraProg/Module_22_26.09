using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Module_22_Wpf
{
    public class WorkerApi
    {
        
         private HttpClient httpClient { get; set; }
        public WorkerApi()
        {
            httpClient = new HttpClient();
        }
        public IEnumerable<Worker> Select()
        {
            string url = @"https://localhost:44351/api/Worker";
            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Worker>>(json);
        }

        public void Create(Worker entity)
        {
            string url = @"https://localhost:44351/api/Worker";
            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;

        }

        //public async Task<bool> Delete(Worker entity)
        //{
        //    dbContext.Worker.Remove(entity);
        //    dbContext.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<Worker> Get(int id)
        //{

        //    var worker = await dbContext.Worker.FirstOrDefaultAsync(w => w.Id == id);
        //    return worker;
        //}

        //public async Task<Worker> GetByName(string name)
        //{
        //    return await dbContext.Worker.FirstOrDefaultAsync(w => w.Name == name);

        //}

        //public async Task<Worker> Update(Worker entity)
        //{
        //    dbContext.Worker.Update(entity);
        //    await dbContext.SaveChangesAsync();
        //    return entity;
        //}
    }
}
