using Associação_Ulbra_Torres.Models.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Utilitarios
{
    public class DependentesUtil
    {
        public static string novaPalavra;
        public static Dependentes newDependente;
        public static List<Dependentes> newList;

        public static Dependentes ToLowerDependente(Dependentes item)
        {
            newDependente = new Dependentes();

            newDependente.idPessoa = item.idPessoa;
            newDependente.idDependente = item.idDependente;
            newDependente.nome = item.nome.ToLower();
            newDependente.email = (item.email == null) ? null : item.email.ToLower();
            newDependente.nacionalidade = item.nacionalidade.ToLower();
            newDependente.naturalidade = item.naturalidade.ToLower();
            newDependente.estadoNaturalidade = item.estadoNaturalidade.ToLower();
            newDependente.dataNascimento = item.dataNascimento;
            newDependente.estadoCivil = item.estadoCivil.ToLower();
            newDependente.cpf = item.cpf;
            newDependente.rg = item.rg;
            newDependente.tituloDeEleitor = item.tituloDeEleitor;
            newDependente.zona = item.zona;
            newDependente.secao = item.secao;
            newDependente.endereco = item.endereco.ToLower();
            newDependente.numero = item.numero;
            newDependente.bairro = item.bairro.ToLower();
            newDependente.cidade = item.cidade.ToLower();
            newDependente.estado = item.estado.ToLower();
            newDependente.cep = item.cep;
            newDependente.sexo = item.sexo;
            newDependente.observacoes = (item.observacoes == null) ? null : item.observacoes.ToLower();
            newDependente.religiao = ReligiaoUtil.ToFirstUpper(item.religiao);
            newDependente.telefones = (item.telefones == null) ? null : item.telefones;
            newDependente.associado = item.associado;
            newDependente.parentesco = item.parentesco.ToLower();
            newDependente.escola = item.escola;

            return newDependente;
        }

        public static Dependentes ToUpperDependente(Dependentes item)
        {
            newDependente = new Dependentes();

            newDependente.idPessoa = item.idPessoa;
            newDependente.idDependente = item.idDependente;
            newDependente.nome = item.nome.ToUpper();
            newDependente.email = (item.email == null) ? null : item.email.ToUpper();
            newDependente.nacionalidade = item.nacionalidade.ToUpper();
            newDependente.naturalidade = item.naturalidade.ToUpper();
            newDependente.estadoNaturalidade = item.estadoNaturalidade.ToUpper();
            newDependente.dataNascimento = item.dataNascimento;
            newDependente.estadoCivil = item.estadoCivil.ToUpper();
            newDependente.cpf = item.cpf;
            newDependente.rg = item.rg;
            newDependente.tituloDeEleitor = item.tituloDeEleitor;
            newDependente.zona = item.zona;
            newDependente.secao = item.secao;
            newDependente.endereco = item.endereco.ToUpper();
            newDependente.numero = item.numero;
            newDependente.bairro = item.bairro.ToUpper();
            newDependente.cidade = item.cidade.ToUpper();
            newDependente.estado = item.estado.ToUpper();
            newDependente.cep = item.cep;
            newDependente.sexo = item.sexo;
            newDependente.observacoes = (item.observacoes == null) ? null : item.observacoes.ToUpper();
            newDependente.religiao = ReligiaoUtil.ToFirstUpper(item.religiao);
            newDependente.telefones = (item.telefones == null) ? null : item.telefones;
            newDependente.associado = item.associado;
            newDependente.parentesco = item.parentesco.ToUpper();
            newDependente.escola = item.escola;

            return newDependente;
        }

        public static Dependentes ToFirstUpper(Dependentes item)
        {
            newDependente = new Dependentes();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            newDependente.idPessoa = item.idPessoa;
            newDependente.idDependente = item.idDependente;
            newDependente.nome = cultureInfo.TextInfo.ToTitleCase(item.nome);
            newDependente.email = (item.email == null) ? null : item.email.ToLower();
            newDependente.nacionalidade = cultureInfo.TextInfo.ToTitleCase(item.nacionalidade);
            newDependente.naturalidade = cultureInfo.TextInfo.ToTitleCase(item.naturalidade);
            newDependente.estadoNaturalidade = item.estadoNaturalidade.ToUpper();
            newDependente.dataNascimento = item.dataNascimento;
            newDependente.estadoCivil = cultureInfo.TextInfo.ToTitleCase(item.estadoCivil);
            newDependente.cpf = item.cpf;
            newDependente.rg = item.rg;
            newDependente.tituloDeEleitor = item.tituloDeEleitor;
            newDependente.zona = item.zona;
            newDependente.secao = item.secao;
            newDependente.endereco = cultureInfo.TextInfo.ToTitleCase(item.endereco);
            newDependente.numero = item.numero;
            newDependente.bairro = cultureInfo.TextInfo.ToTitleCase(item.bairro);
            newDependente.cidade = cultureInfo.TextInfo.ToTitleCase(item.cidade);
            newDependente.estado = item.estado.ToUpper();
            newDependente.cep = item.cep;
            newDependente.sexo = item.sexo;
            newDependente.observacoes = (item.observacoes == null) ? null : item.observacoes.ToLower();
            newDependente.religiao = ReligiaoUtil.ToFirstUpper(item.religiao);
            newDependente.telefones = (item.telefones == null) ? null : item.telefones;
            newDependente.associado = item.associado;
            newDependente.parentesco = cultureInfo.TextInfo.ToTitleCase(item.parentesco);
            newDependente.escola = item.escola;

            return newDependente;
        }

        public static List<Dependentes> ToFirstUpper(List<Dependentes> pLista)
        {
            newList = new List<Dependentes>();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            foreach (var item in pLista)
            {
                newList.Add
                (
                    new Dependentes
                    {
                        idDependente = item.idDependente,
                        idPessoa = item.idPessoa,
                        nome = cultureInfo.TextInfo.ToTitleCase(item.nome),
                        email = (item.email == null) ? null : item.email.ToLower(),
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
                        religiao = ReligiaoUtil.ToFirstUpper(item.religiao),
                        telefones = (item.telefones == null) ? null : item.telefones,
                        associado = item.associado,
                        parentesco = cultureInfo.TextInfo.ToTitleCase(item.parentesco),
                        escola = item.escola
                    }
                );
            }

            return newList;
        }

        public static List<Dependentes> ToFirstUpperAniver(List<Dependentes> pLista)
        {
            newList = new List<Dependentes>();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            foreach (var item in pLista)
            {
                newList.Add
                (
                    new Dependentes
                    {
                        nome = cultureInfo.TextInfo.ToTitleCase(item.nome),
                        dataNascimento = item.dataNascimento,
                        email = (item.email == null) ? null : item.email.ToLower()
                    }
                );
            }

            return newList;
        }

        public static List<Dependentes> ToFirstUpperEleitores(List<Dependentes> pLista)
        {
            newList = new List<Dependentes>();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            foreach (var item in pLista)
            {
                newList.Add
                (
                    new Dependentes
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