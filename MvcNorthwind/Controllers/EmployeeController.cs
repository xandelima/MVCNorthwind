using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNorthwind.Models;
using Repositorio.Base;
using NHibernate;
using Dominio.Repositorios;

namespace MvcNorthwind.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            ISession session = NHibernateSessionManager.GetSession();
            IRepositorio<Employee> empRep = new NhRepo<Employee>();
            
            IList<Employee> emp = empRep.PesquisarLista();

            return View(emp);
        }
    }
}
