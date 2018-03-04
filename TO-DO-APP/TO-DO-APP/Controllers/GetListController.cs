using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TO_DO_APP.DAO;
using TO_DO_APP.Database;
using TO_DO_APP.Models;

namespace TO_DO_APP.Areas.GetList
{
    [RoutePrefix("api/getlist")]
    public class GetListController : ApiController
    {
        [HttpGet]
        [Route("alltask")]
        public IHttpActionResult allTask() 
        {
            GetTaskDAO dataList = new GetTaskDAO();
            List<ToDoModel> result = dataList.GetAllTask();
            return Ok(result);

        }

        [HttpGet]
        [Route("singletask")]
        public IHttpActionResult singleTask(string TaskId)
        {
            GetTaskDAO dataList = new GetTaskDAO();
            ToDoModel result = dataList.GetSingleTask(TaskId);
            return Ok(result);

        }

        [HttpPost]
        [Route("addtask")]
        public IHttpActionResult addTask(ToDoModel dataInsert)
        {
            GetTaskDAO dataList = new GetTaskDAO();
            bool result = dataList.AddTask(dataInsert);
            return Ok(result);
        }

        [HttpPost]
        [Route("edittask")]
        public IHttpActionResult editTask(ToDoModel dataEdit)
        {
            GetTaskDAO dataList = new GetTaskDAO();
            bool result = dataList.EditTask(dataEdit);
            return Ok(result);
        }

        [HttpPost]
        [Route("changestatustask")]
        public IHttpActionResult changeStatusTask(ToDoModel statusChange)
        {
            GetTaskDAO dataList = new GetTaskDAO();
            bool result = dataList.ChangeStatusTask(statusChange);
            return Ok(result);
        }

        [HttpGet]
        [Route("deletetask")]
        public IHttpActionResult deleteTask(string TaskId)
        {
            GetTaskDAO dataList = new GetTaskDAO();
            bool result = dataList.DeleteTask(TaskId);
            return Ok(result);
        }
    }
}