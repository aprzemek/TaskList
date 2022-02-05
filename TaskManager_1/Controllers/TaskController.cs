using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager_1.Models;

namespace TaskManager_1.Controllers
{
    public class TaskController : Controller
    {

        public static IList<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel(){ TaskId = 1, Name = "Fryzjer", Description = "17:00", Done = false}
        };
        // GET: TaskController
        public ActionResult Index()
        {
            return View(tasks.Where(x => !x.Done));
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            taskModel.TaskId = tasks.Count + 1;
            tasks.Add(taskModel);
                return RedirectToAction(nameof(Index));
          
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tasks.FirstOrDefault(x=> x.TaskId == id));
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Name = task.Name;
            task.Description = taskModel.Description;
               return RedirectToAction(nameof(Index));
            
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            tasks.Remove(task);
            return RedirectToAction(nameof(Index));
           
        }
        //GET: Task/Done/5
        public ActionResult Done(int id)
        {
            TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
            task.Done = true;

            return RedirectToAction(nameof(Index));
        }
    }
}
