using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSlate.Core.DTO
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Estimated_Hours { get; set; }
        public string Created_By { get; set; }
        public bool Completed { get; set; }
    }
}
