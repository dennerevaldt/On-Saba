using Associação_Ulbra_Torres.Models.Entidade;
using Associação_Ulbra_Torres.Models.Repositorio;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Associação_Ulbra_Torres.Controllers
{
    [Authorize]
    public class AssociadosController : Controller
    {
        //ASSOCIADOS -----------------------------------------------

        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            ViewBag.associados = "active";

            List<Associados> lista = AssociadosRepositorio.Get();

            //quando entrar a primeira vez os valores page e pagezise serao os definidos
            //durante a execucao os parametros recebem a page que esta sendo escolhida e tamanho poe GET
            //e retorna os itens da lista

            //instancia-se uma nova PagedList passando como parametro a lista retornada, 
            //pagina inicial e numero maximo de itens por pagina
            PagedList<Associados> pg = new PagedList<Associados>(lista, page, pageSize);

            return View(pg);
        }

        public ActionResult AdicionarAssociado()
        {
            ViewBag.associados = "active";
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarAssociado(Associados pAssociado)
        {
            AssociadosRepositorio.Create(pAssociado);
            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int page = 1, int pageSize = 5)
        {
            ViewBag.associados = "active";

            List<Associados> lista = AssociadosRepositorio.Get();

            PagedList<Associados> pg = new PagedList<Associados>(lista, page, pageSize);
            return View(pg);
        }

        public ActionResult DeletarConfirma(string pIdAssociado)
        {
            Associados associado = AssociadosRepositorio.GetOne(pIdAssociado);
            AssociadosRepositorio.Delete(associado);
            return RedirectToAction("Deletar");
        }

        public ActionResult Editar(int page = 1, int pageSize = 5)
        {
            ViewBag.associados = "active";

            List<Associados> lista = AssociadosRepositorio.Get();

            PagedList<Associados> pg = new PagedList<Associados>(lista, page, pageSize);
            return View(pg);
        }

        public ActionResult EditarDetalhes(string pIdAssociado)
        {
            ViewBag.associados = "active";
            Associados associado = AssociadosRepositorio.GetOne(pIdAssociado);
            return View(associado);
        }

        [HttpPost]
        public ActionResult EditarDetalhes(Associados pAssociado)
        {
            AssociadosRepositorio.Edit(pAssociado);
            return RedirectToAction("Editar");
        }

        public ActionResult Buscar()
        {
            ViewBag.associados = "active";
            return View();
        }

        public PartialViewResult BuscaAssociados(string nomeAssociado)
        {
            List<Associados> lista = AssociadosRepositorio.Get(nomeAssociado);

            if (lista.Count == 0)
            {
                ViewBag.aviso = "Nenhum Associado encontrado.";
            }

            return PartialView(lista);
        }

        //DEPENDENTES -----------------------------------------------

        public ActionResult ListaDependentes(string pIdAssociado)
        {
            ViewBag.associados = "active";

            ViewBag.IdAssociado = pIdAssociado;
            List<Dependentes> lista = DependentesRepositorio.Get(pIdAssociado);

            if (lista.Count != 0)
            {
                ViewBag.nomeAssociado = lista[0].associado.nome;
            }
            else
            {
                Associados associado = AssociadosRepositorio.GetOne(pIdAssociado);
                ViewBag.nomeAssociado = associado.nome;
            }

            return View(lista);
        }

        public ActionResult AdicionarDependente(string pIdAssociado)
        {
            ViewBag.associados = "active";

            ViewBag.IdAssociado = pIdAssociado;
            List<Escolas> lista = EscolasRepositorio.Get();
            ViewBag.listaEscolas = new SelectList(lista, "idEscola", "nomeEscola");

            return View();
        }

        [HttpPost]
        public ActionResult AdicionarDependente(Dependentes pDependente)
        {
            DependentesRepositorio.Create(pDependente);
            return RedirectToAction("ListaDependentes", new { pIdAssociado = pDependente.associado.idAssociado });
        }

        public ActionResult DeletarDependente(string pIdAssociado)
        {
            ViewBag.associados = "active";

            ViewBag.IdAssociado = pIdAssociado;
            List<Dependentes> lista = DependentesRepositorio.Get(pIdAssociado);
            return View(lista);
        }

        public ActionResult DeletarDependenteConfirma(string pIdDependente, string pIdAssociado)
        {
            Dependentes dependente = DependentesRepositorio.GetOne(pIdDependente);
            DependentesRepositorio.Delete(dependente);
            return RedirectToAction("DeletarDependente", new { pIdAssociado = pIdAssociado });
        }

        public ActionResult EditarDependente(string pIdAssociado)
        {
            ViewBag.associados = "active";

            ViewBag.idAssociado = pIdAssociado;
            List<Dependentes> lista = DependentesRepositorio.Get(pIdAssociado);
            return View(lista);
        }

        public ActionResult EditarDependenteDetalhes(string pIdDependente)
        {
            ViewBag.associados = "active";

            Dependentes dependente = DependentesRepositorio.GetOne(pIdDependente);

            List<Escolas> lista = EscolasRepositorio.Get();
            ViewBag.listaEscolas = new SelectList(lista, "idEscola", "nomeEscola");

            return View(dependente);
        }

        [HttpPost]
        public ActionResult EditarDependenteDetalhes(Dependentes pDependente)
        {
            DependentesRepositorio.Edit(pDependente);
            return RedirectToAction("EditarDependente", new { pIdAssociado = pDependente.associado.idAssociado });

        }

        //CARTEIRINHA ------------------------------------------------------------

        public ActionResult GerarCarteira(string pIdAssociado)
        {
            Associados associado = AssociadosRepositorio.GetOne(pIdAssociado);
            return View("Carteirinha", associado);
        }


    }
}
