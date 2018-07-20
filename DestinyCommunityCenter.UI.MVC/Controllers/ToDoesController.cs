using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DestinyCommunityCenter.EF.DATA;

namespace DestinyCommunityCenter.UI.MVC.Controllers
{
    public class ToDoesController : Controller
    {
        private DestinyCommunityCenterEntities db = new DestinyCommunityCenterEntities();

        // GET: ToDoes
        [Authorize]
        public ActionResult Index()
        {
            var toDos = db.ToDos.Include(t => t.ToDoList);
            return View(toDos.ToList());
        }

        // GET: ToDoes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        // GET: ToDoes/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.ToDoListID = new SelectList(db.ToDoLists, "ToDoListID", "ListName");
            return View();
        }

        // POST: ToDoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ToDoID,Title,Description,DateAdded,IsComplete,ToDoListID")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.ToDos.Add(toDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ToDoListID = new SelectList(db.ToDoLists, "ToDoListID", "ListName", toDo.ToDoListID);
            return View(toDo);
        }

        // GET: ToDoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ToDoListID = new SelectList(db.ToDoLists, "ToDoListID", "ListName", toDo.ToDoListID);
            return View(toDo);
        }

        // GET: ToDoes/Edit/5
        [Authorize]
        public ActionResult EditVolunteer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ToDoListID = new SelectList(db.ToDoLists, "ToDoListID", "ListName", toDo.ToDoListID);
            return View(toDo);
        }

        // POST: ToDoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ToDoID,Title,Description,DateAdded,IsComplete,ToDoListID")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ToDoListID = new SelectList(db.ToDoLists, "ToDoListID", "ListName", toDo.ToDoListID);
            return View(toDo);
        }

        // POST: ToDoes/Edit/5
        //Volunterr can edit task as being COMPLETE ONLY! View for Task Details has button to this page.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Volunteer")]
        public ActionResult EditVolunteer([Bind(Include = "IsComplete")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ToDoListID = new SelectList(db.ToDoLists, "ToDoListID", "ListName", toDo.ToDoListID);
            return View(toDo);
        }

        // GET: ToDoes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        // POST: ToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDo toDo = db.ToDos.Find(id);
            db.ToDos.Remove(toDo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
