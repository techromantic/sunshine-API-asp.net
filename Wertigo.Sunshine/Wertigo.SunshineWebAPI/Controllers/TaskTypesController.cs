using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wertigo.SunshineWebAPI.Models.DataModel;
using Wertigo.SunshineWebAPI.Models.ViewModel;

namespace Wertigo.SunshineWebAPI.Controllers
{
    public class TaskTypesController : ApiController, IDisposable
    {

        private SunshineEntities db = new SunshineEntities();

        public IHttpActionResult Get()
        {
            return Ok(db.TaskTypes.Where(a => a.IsActive).Select(b => new
            {
                Id = b.Id,
                Name = b.TaskType1
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
