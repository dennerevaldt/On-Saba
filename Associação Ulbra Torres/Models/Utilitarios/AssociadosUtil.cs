using Associação_Ulbra_Torres.Models.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Threading;

namespace Associação_Ulbra_Torres.Models.Utilitarios
{
    public class AssociadosUtil
    {
        public static string novaPalavra;
        public static Associados newAssociado;
        public static List<Associados> newList;

        public static Associados ToLowerAssociado(Associados item)
        {
            newAssociado = new Associados();

            newAssociado.idPessoa = item.idPessoa;
            newAssociado.idAssociado = item.idAssociado;
            newAssociado.nome = item.nome.ToLower();
            newAssociado.nacionalidade = item.nacionalidade.ToLower();
            newAssociado.naturalidade = item.naturalidade.ToLower();
            newAssociado.estadoNaturalidade = item.estadoNaturalidade.ToLower();
            newAssociado.dataNascimento = item.dataNascimento;
            newAssociado.estadoCivil = item.estadoCivil.ToLower();
            newAssociado.cpf = item.cpf;
            newAssociado.rg = item.rg;
            newAssociado.tituloDeEleitor = item.tituloDeEleitor;
            newAssociado.zona = item.zona;
            newAssociado.secao = item.secao;
            newAssociado.endereco = item.endereco.ToLower();
            newAssociado.numero = item.numero;
            newAssociado.bairro = item.bairro.ToLower();
            newAssociado.cidade = item.cidade.ToLower();
            newAssociado.estado = item.estado.ToLower();
            newAssociado.cep = item.cep;
            newAssociado.sexo = item.sexo;
            newAssociado.observacoes = (item.observacoes == null) ? null : item.observacoes.ToLower();
            newAssociado.tipoResidencia = item.tipoResidencia.ToLower();
            newAssociado.email = (item.email == null) ? null : item.email.ToLower();
            newAssociado.religiao = ReligiaoUtil.ToFirstUpper(item.religiao);
            newAssociado.telefones = (item.telefones == null) ? null : item.telefones;

            return newAssociado;
        }

        public static Associados ToUpperAssociado(Associados item)
        {
            newAssociado = new Associados();

            newAssociado.idPessoa = item.idPessoa;
            newAssociado.idAssociado = item.idAssociado;
            newAssociado.nome = item.nome.ToUpper();
            newAssociado.nacionalidade = item.nacionalidade.ToUpper();
            newAssociado.naturalidade = item.naturalidade.ToUpper();
            newAssociado.estadoNaturalidade = item.estadoNaturalidade.ToUpper();
            newAssociado.dataNascimento = item.dataNascimento;
            newAssociado.estadoCivil = item.estadoCivil.ToUpper();
            newAssociado.cpf = item.cpf;
            newAssociado.rg = item.rg;
            newAssociado.tituloDeEleitor = item.tituloDeEleitor;
            newAssociado.zona = item.zona;
            newAssociado.secao = item.secao;
            newAssociado.endereco = item.endereco.ToUpper();
            newAssociado.numero = item.numero;
            newAssociado.bairro = item.bairro.ToUpper();
            newAssociado.cidade = item.cidade.ToUpper();
            newAssociado.estado = item.estado.ToUpper();
            newAssociado.cep = item.cep;
            newAssociado.sexo = item.sexo;
            newAssociado.observacoes = (item.observacoes == null) ? null : item.observacoes.ToUpper();
            newAssociado.tipoResidencia = item.tipoResidencia.ToUpper();
            newAssociado.email = (item.email == null) ? null : item.email.ToUpper();
            newAssociado.religiao = ReligiaoUtil.ToFirstUpper(item.religiao);
            newAssociado.telefones = (item.telefones == null) ? null : item.telefones;

            return newAssociado;
        }

        public static Associados ToFirstUpper(Associados item)
        {
            newAssociado = new Associados();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            newAssociado.idPessoa = item.idPessoa;
            newAssociado.idAssociado = item.idAssociado;
            newAssociado.nome = cultureInfo.TextInfo.ToTitleCase(item.nome);
            newAssociado.nacionalidade = cultureInfo.TextInfo.ToTitleCase(item.nacionalidade);
            newAssociado.naturalidade = cultureInfo.TextInfo.ToTitleCase(item.naturalidade);
            newAssociado.estadoNaturalidade = cultureInfo.TextInfo.ToTitleCase(item.estadoNaturalidade);
            newAssociado.dataNascimento = item.dataNascimento;
            newAssociado.estadoCivil = cultureInfo.TextInfo.ToTitleCase(item.estadoCivil);
            newAssociado.cpf = item.cpf;
            newAssociado.rg = item.rg;
            newAssociado.tituloDeEleitor = item.tituloDeEleitor;
            newAssociado.zona = item.zona;
            newAssociado.secao = item.secao;
            newAssociado.endereco = cultureInfo.TextInfo.ToTitleCase(item.endereco);
            newAssociado.numero = item.numero;
            newAssociado.bairro = cultureInfo.TextInfo.ToTitleCase(item.bairro);
            newAssociado.cidade = cultureInfo.TextInfo.ToTitleCase(item.cidade);
            newAssociado.estado = item.estado.ToUpper();
            newAssociado.cep = item.cep;
            newAssociado.sexo = item.sexo;
            newAssociado.observacoes = (item.observacoes == null) ? null : item.observacoes.ToLower();
            newAssociado.tipoResidencia = cultureInfo.TextInfo.ToTitleCase(item.tipoResidencia);
            newAssociado.email = (item.email == null) ? null : item.email.ToLower();
            newAssociado.religiao = ReligiaoUtil.ToFirstUpper(item.religiao);
            newAssociado.telefones = (item.telefones == null) ? null : item.telefones;
            newAssociado.dependentes = (item.dependentes == null) ? null : item.dependentes;

            return newAssociado;
        }

        public static List<Associados> ToFirstUpper(List<Associados> pLista)
        {
            newList = new List<Associados>();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            foreach (var item in pLista)
            {
                newList.Add
                (
                    new Associados
                    {
                        idAssociado = item.idAssociado,
                        idPessoa = item.idPessoa,
                        nome = cultureInfo.TextInfo.ToTitleCase(item.nome),
                        nacionalidade = cultureInfo.TextInfo.ToTitleCase(item.nacionalidade),
                        naturalidade = cultureInfo.TextInfo.ToTitleCase(item.naturalidade),
                        estadoNaturalidade = item.estadoNaturalidade.ToUpper(),
                        dataNascimento = item.dataNascimento,
                        estadoCivil = cultureInfo.TextInfo.ToTitleCase(item.estadoCivil),
                        cpf = item.cpf,
                        rg = item.rg,
                        tituloDeEleitor = item.tituloDeEleitor,
                        zona = item.zona,
                        secao = item.secao,
                        endereco = cultureInfo.TextInfo.ToTitleCase(item.endereco),
                        numero = item.numero,
                        bairro = cultureInfo.TextInfo.ToTitleCase(item.bairro),
                        cidade = cultureInfo.TextInfo.ToTitleCase(item.cidade),
                        estado = item.estado.ToUpper(),
                        cep = item.cep,
                        sexo = item.sexo,
                        observacoes = (item.observacoes == null) ? null : item.observacoes.ToLower(),
                        tipoResidencia = cultureInfo.TextInfo.ToTitleCase(item.tipoResidencia),
                        email = (item.email == null) ? null : item.email.ToLower(),
                        religiao = ReligiaoUtil.ToFirstUpper(item.religiao),
                        telefones = (item.telefones == null) ? null : item.telefones,
                        dependentes = (item.dependentes == null) ? null : item.dependentes
                    }
                );
            }

            return newList;
        }

        public static List<Associados> ToFirstUpperAniver(List<Associados> pLista)
        {
            newList = new List<Associados>();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            foreach (var item in pLista)
            {
                newList.Add
                (
                    new Associados
                    {
                        nome = cultureInfo.TextInfo.ToTitleCase(item.nome),
                        dataNascimento = item.dataNascimento,
                        email = (item.email == null) ? null : item.email.ToLower()
                    }
                );
            }

            return newList;
        }

        public static List<Associados> ToFirstUpperEleitores(List<Associados> pLista)
        {
            newList = new List<Associados>();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            foreach (var item in pLista)
            {
                newList.Add
                (
                    new Associados
                    {
                        nome = cultureInfo.TextInfo.ToTitleCase(item.nome),
                        tituloDeEleitor = item.tituloDeEleitor,
                        zona = item.zona,
                        secao = item.secao
                    }
                );
            }

            return newList;
        }
    }
}