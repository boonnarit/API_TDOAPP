using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TO_DO_APP.Models
{
    public class ToDoModel
    {
        public string Task_id { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
    }
}