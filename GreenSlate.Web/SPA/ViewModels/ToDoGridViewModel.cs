using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenSlate.Web.SPA.ViewModels
{
    public class ToDoGridViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Estimated_Hours { get; set; }
        public string Created_By { get; set; }
        public bool Completed { get; set; }
    }
}