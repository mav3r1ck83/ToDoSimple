using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenSlate.Web.SPA.ViewModels
{
    public class ToDoGridViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Title { get; set; }
        [Required]
        public int Estimated_Hours { get; set; }
       
        public string Created_By { get; set; }
        public bool Completed { get; set; }
    }
}