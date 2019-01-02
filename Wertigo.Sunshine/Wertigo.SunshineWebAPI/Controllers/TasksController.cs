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

    public class TasksController : ApiController
    {

        private SunshineEntities db = new SunshineEntities();

        [Authorize]
        public IHttpActionResult Get(DateTime date)
        {
            //ToDo: to return all the tasks for a user and its schedule.
            return null;
        }

        [Authorize]
        public IHttpActionResult Get(string TaskId)
        {
            var userId = db.AspNetUsers.Where(a => a.Email == RequestContext.Principal.Identity.Name).Select(b => b.Id).First();
            return Ok(db.Tasks.Where(a => a.Id.ToString() == TaskId && a.UserId == userId).Select(b => new
            {
                Title = b.Title,
                Notes = b.Notes,
                Priority = b.TaskPriority,
                Status = b.TaskStatusId,
                StatusText = b.TaskStatu.TaskStatus,
                Type = b.TaskType,
                TypeText = b.TaskType.TaskType1,
                IsDeleted = b.IsDeleted
            }));
        }

        [Authorize]
        public IHttpActionResult Post(TaskPostViewModel input)
        {
            if(!ModelState.IsValid)
            {
                return InternalServerError(new Exception("Input data Invalid."));
            }
            var userId = db.AspNetUsers.Where(a => a.Email == RequestContext.Principal.Identity.Name).Select(b => b.Id).First();
            db.Tasks.Add(new Task
            {
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Notes = input.Notes,
                TaskPriority = input.Priority,
                TaskStatusId = input.TaskStatusId,
                TaskTypeId = input.TaskTypeId,
                Title = input.Title,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now,
                UserId = userId,
                Id = Guid.NewGuid()
            });
            db.SaveChanges();
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
