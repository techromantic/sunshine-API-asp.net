using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wertigo.SunshineWebAPI.Models.ViewModel
{
    public class TaskPostViewModel
    {

        public string Title { get; set; }
        public byte TaskTypeId { get; set; }
        public byte TaskStatusId { get; set; }
        public byte Priority { get; set; }
        public string Notes { get; set; }
        public Boolean IsDeleted { get; set; }

    }
}