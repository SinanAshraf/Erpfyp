using Erpfyp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Erpfyp.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context = null;
        private ERPFYPEntities db = new ERPFYPEntities();
        
        // GET: Role
        public ActionResult Index()
        {
            context = new ApplicationDbContext();
            if (User.Identity.IsAuthenticated)
            {
                
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AspNetRole model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists(model.Name))
            {
                // first we create Admin role    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = model.Name;
                roleManager.Create(role);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(AspNetRole role)
        {
            if (role.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (role.Name.ToLower() == User.Identity.Name.ToLower())
            {
                ViewBag.message = "could not delete current user Role.";
                return RedirectToAction("Index");
            }
                AspNetRole roles = db.AspNetRoles.Find(role.Id);
                return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRole(AspNetRole model)
        {
            if (model.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole role = db.AspNetRoles.Find(model.Id);
            if (role == null)
            {
                return HttpNotFound();
            }
            else if (ModelState.IsValid)
            {
                db.AspNetRoles.Remove(role);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}