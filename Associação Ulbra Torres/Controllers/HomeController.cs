using Associação_Ulbra_Torres.Models;
using Associação_Ulbra_Torres.Models.Entidade;
using Associação_Ulbra_Torres.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Associação_Ulbra_Torres.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.home = "active";

            int contEscolas = EscolasRepositorio.GetContador();
            ViewBag.contadorEscolas = contEscolas;

            int contAssociados = AssociadosRepositorio.GetContador();
            ViewBag.contadorAssociados = contAssociados;

            List<Associados> lista = AssociadosRepositorio.GetAniversariantes();
            int contAniverAssoc = lista.Count();
            List<Dependentes> lista2 = DependentesRepositorio.GetAniversariantes();
            int contAniverDepen = lista2.Count();
            ViewBag.contadorAniversariantes = contAniverAssoc+contAniverDepen;

            List<Associados> listaEle = AssociadosRepositorio.GetEleitores();
            int contEleitores = listaEle.Count();
            List<Dependentes> listaEle2 = DependentesRepositorio.GetEleitores();
            int contEleitores2 = listaEle2.Count();
            ViewBag.contadorEleitores = contEleitores+contEleitores2;

            return View();
        }

        public ActionResult Aniversariantes()
        {
            ViewBag.aniversariantes = "active";

            return View();
        }

        public ActionResult AssociadosAniversario()
        {
            List<Associados> lista = AssociadosRepositorio.GetAniversariantes();

            if (lista.Count == 0)
            {
                ViewBag.aviso = "Nenhum Associado de Aniversário.";
            }

            return PartialView("AssociadosAniversario",lista);
        }

        public ActionResult DependentesAniversario()
        {
            List<Dependentes> lista = DependentesRepositorio.GetAniversariantes();

            if (lista.Count == 0)
            {
                ViewBag.aviso = "Nenhum Dependente de Aniversário.";
            }

            return PartialView("DependentesAniversario", lista);
        }

        public ActionResult Eleitores()
        {
            ViewBag.Eleitores = "active";
            return View();
        }

        public ActionResult AssociadosEleitores()
        {
            List<Associados> lista = AssociadosRepositorio.GetEleitores();

            if (lista.Count == 0)
            {
                ViewBag.aviso = "Nenhum Associado Eleitor";
            }

            return PartialView("AssociadosEleitores", lista);
        }

        public ActionResult DependentesEleitores()
        {
            List<Dependentes> lista = DependentesRepositorio.GetEleitores();

            if (lista.Count == 0)
            {
                ViewBag.aviso = "Nenhum Dependente Eleitor";
            }

            return PartialView("DependentesEleitores", lista);

        }

        public ActionResult Pessoas()
        {
            ViewBag.pessoas = "active";

            ViewBag.contHomens = PessoasRepositorio.NumeroHomens();
            ViewBag.contMulheres = PessoasRepositorio.NumeroMulheres();

            ViewBag.contHomensCriancas = PessoasRepositorio.NumeroCriancasHomens();
            ViewBag.contMulheresCriancas = PessoasRepositorio.NumeroCriancasMulheres();

            ViewBag.contHomensAdultos = PessoasRepositorio.NumeroAdultosHomens();
            ViewBag.contMulheresAdultos = PessoasRepositorio.NumeroAdultosMulheres();

            ViewBag.contHomensIdosos = PessoasRepositorio.NumeroIdososHomens();
            ViewBag.contMulheresIdosos = PessoasRepositorio.NumeroIdososMulheres();

            ViewBag.contTotal = PessoasRepositorio.NumeroHomens() + PessoasRepositorio.NumeroMulheres();

            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.sobre = "active";
            return View();
        }

    }
}