using System;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using projeto.Models;
using NhibernateMVC.Models;

namespace projeto.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var employees = session.Query<Produto>().ToList();
                return View(employees);
            }

        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                using (ISession session = NHibertnateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(produto);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var produto = session.Get<Produto>(id);
                return View(produto);
            }

        }

        [HttpPost]
        public ActionResult Edit(int id, Produto produto)
        {
            try
            {
                using (ISession session = NHibertnateSession.OpenSession())
                {
                    var produtoUpdate = session.Get<Produto>(id);

                    produtoUpdate.Nome = produto.Nome;

                    if (produtoUpdate.Valor != produto.Valor)
                    {
                        produtoUpdate.Valor = produto.Valor;
                    }

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(produtoUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Details(int id)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var produto = session.Get<Produto>(id);
                return View(produto);
            }
        }


        public ActionResult Delete(int id)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var employee = session.Get<Produto>(id);
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Produto produto)
        {
            try
            {
                using (ISession session = NHibertnateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(produto);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

    }
}
