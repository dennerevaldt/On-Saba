using Associação_Ulbra_Torres.Models;
using Associação_Ulbra_Torres.Models.Entidade;
using Associação_Ulbra_Torres.Models.Repositorio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Associação_Ulbra_Torres.Controllers
{
    [Authorize]
    public class EscolasController : Controller
    {
        public static List<Dependentes> lista;

        public ActionResult Index()
        {
            ViewBag.escolas = "active";
            List<Escolas> lista = EscolasRepositorio.Get();
            return View(lista);
        }

        public ActionResult AdicionarEscola()
        {
            ViewBag.escolas = "active";
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarEscola(Escolas pEscola)
        {
            EscolasRepositorio.Create(pEscola);
            return RedirectToAction("Index");
        }

        public ActionResult Deletar()
        {
            ViewBag.escolas = "active";
            List<Escolas> lista = EscolasRepositorio.Get();
            return View(lista);
        }

        public ActionResult DeletarConfirma(string pIdEscola)
        {
            try
            {
                Escolas escola = EscolasRepositorio.GetOne(pIdEscola);
                EscolasRepositorio.Delete(escola);
                return RedirectToAction("Deletar");
            }
            catch (MySqlException ex)
            {
                return View("_erroDelete");
            }
            
        }

        public ActionResult Editar()
        {
            ViewBag.escolas = "active";
            List<Escolas> lista = EscolasRepositorio.Get();
            return View(lista);
        }

        public ActionResult EditarDetalhes(string pIdEscola)
        {
            ViewBag.escolas = "active";
            Escolas escola = EscolasRepositorio.GetOne(pIdEscola);
            return View(escola);
        }

        [HttpPost]
        public ActionResult EditarDetalhes(Escolas pEscola)
        {
            EscolasRepositorio.Edit(pEscola);
            return RedirectToAction("Editar");
        }

        // Action para listar a pagina de busca e escola disponiveis para pesquisa
        public ActionResult DependentePorEscola()
        {
            ViewBag.escolas = "active";
            List<Escolas> lista = EscolasRepositorio.Get();
            ViewBag.listaEscolas = new SelectList(lista, "idEscola", "nomeEscola");
            return View();
        }

        // Action post de pesquisa de Dependentes por Escola

        [HttpPost,ActionName("DependentePorEscola")]
        public ActionResult DependentePorEscola(Escolas pEscola)
        {
            lista = DependentesRepositorio.GetDependentePorEscola(pEscola.idEscola);
            return RedirectToAction("ListaDependentesPorEscola");
        }

        // Action exibi resultados da pesquisa de Dependentes por Escola
        public ActionResult ListaDependentesPorEscola()
        {
            ViewBag.escolas = "active";
            if (lista.Count() <= 0)
            {
                ViewBag.aviso = "Nenhum estudante encontrado!";
            }
            return View(lista);
        }
    }
}