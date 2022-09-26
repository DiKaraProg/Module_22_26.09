using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_21_MVC_Domain.ViewModels.Worker
{
    public class WorkerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Note { get; set; }
    }
}
