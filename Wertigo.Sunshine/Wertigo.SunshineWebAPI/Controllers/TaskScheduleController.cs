using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wertigo.SunshineWebAPI.Models.DataModel;

namespace Wertigo.SunshineWebAPI.Controllers
{
    public class TaskScheduleController : ApiController
    {

        private SunshineEntities db = new SunshineEntities();

        [Authorize]
        public IHttpActionResult Post()
        {
            return Ok();
        }

        public new void Dispose()
        {
            base.Dispose();
            db.Dispose();
            db = null;
        }


    }
}
