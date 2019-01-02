using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wertigo.SunshineWebAPI.Models.DataModel;

namespace Wertigo.SunshineWebAPI.Controllers
{
    public class TaskStatusController : ApiController
    {

        private SunshineEntities db = new SunshineEntities();

        public IHttpActionResult Get()
        {
            return Ok(db.TaskStatus.Where(a => a.IsActive).Select(b => new
            {
                Id = b.Id,
                Name = b.TaskStatus
            }).ToList());
        }

        public new void Dispose()
        {
            base.Dispose();
            db.Dispose();
            db = null;
        }

    }
}
