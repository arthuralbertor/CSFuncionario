using CSFuncionario.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CSFuncionario.Controllers
{
    public class HomeController : Controller
    {
        CSFEntities BD = new CSFEntities();

        //Exibir CRUD
        public ActionResult Index()
        {
            return View(BD.func.ToList());
        }

        //Criar Funcionário
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "codFuncionario,nome,dataNascimento,salario,atividades")] func create)
        {
            if (ModelState.IsValid)
            {
                BD.Entry(create).State = EntityState.Added;
                BD.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        //Alterar dados Funcionário
        public ActionResult Edit(int? id)
        {
            func edit = BD.func.Find(id);
            if (edit == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed([Bind(Include = "codFuncionario, nome, dataNascimento, salario, atividades")] func edit)
        {
            if (ModelState.IsValid)
            {
                BD.Entry(edit).State = EntityState.Modified;
                BD.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        //Deletar funcionário
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            func delete = BD.func.Find(id);

            if (delete == null)
            {
                return HttpNotFound();
            }
            return View(delete);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (ModelState.IsValid)
            {
                func delete = BD.func.Find(id);
                BD.func.Remove(delete);
                BD.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}