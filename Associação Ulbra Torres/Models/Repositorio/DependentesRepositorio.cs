using Associação_Ulbra_Torres.Models.Entidade;
using Associação_Ulbra_Torres.Models.Utilitarios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Repositorio
{
    public class DependentesRepositorio
    {
        public static Dependentes dependente;

        /// <summary>
        /// Metodo para editar os dados de um Dependente. Recebe como parametro um objeto do tipo Dependentes.
        /// </summary>
        /// <param name="pDependenteNaoTratado">Objeto Dependentes.</param>
        public static void Edit(Dependentes pDependenteNaoTratado)
        {
            MySqlCommand cmm = new MySqlCommand();
            Dependentes pDependente = DependentesUtil.ToLowerDependente(pDependenteNaoTratado);

            string formatForMySql = pDependente.dataNascimento.ToString("yyyy-MM-dd");
            DateTime dateValue = DateTime.Parse(formatForMySql);

            cmm.Parameters.AddWithValue("@idPessoa", pDependente.idPessoa);
            cmm.Parameters.AddWithValue("@idDependente", pDependente.idDependente);
            cmm.Parameters.AddWithValue("@idEscola", pDependente.escola.idEscola);
            cmm.Parameters.AddWithValue("@nome", pDependente.nome);
            cmm.Parameters.AddWithValue("@nacionalidade", pDependente.nacionalidade);
            cmm.Parameters.AddWithValue("@naturalidade", pDependente.naturalidade);
            cmm.Parameters.AddWithValue("@estadoNaturalidade", pDependente.estadoNaturalidade);
            cmm.Parameters.AddWithValue("@dataNascimento", dateValue);
            cmm.Parameters.AddWithValue("@estadoCivil", pDependente.estadoCivil);
            cmm.Parameters.AddWithValue("@cpf", pDependente.cpf);
            cmm.Parameters.AddWithValue("@rg", pDependente.rg);
            cmm.Parameters.AddWithValue("@tituloDeEleitor", pDependente.tituloDeEleitor);
            cmm.Parameters.AddWithValue("@zona", pDependente.zona);
            cmm.Parameters.AddWithValue("@secao", pDependente.secao);
            cmm.Parameters.AddWithValue("@endereco", pDependente.endereco);
            cmm.Parameters.AddWithValue("@numero", pDependente.numero);
            cmm.Parameters.AddWithValue("@bairro", pDependente.bairro);
            cmm.Parameters.AddWithValue("@cidade", pDependente.cidade);
            cmm.Parameters.AddWithValue("@estado", pDependente.estado);
            cmm.Parameters.AddWithValue("@cep", pDependente.cep);
            cmm.Parameters.AddWithValue("@sexo", pDependente.sexo);
            cmm.Parameters.AddWithValue("@observacoes", pDependente.observacoes);
            cmm.Parameters.AddWithValue("@parentesco", pDependente.parentesco);
            cmm.Parameters.AddWithValue("@religiao", pDependente.religiao.nome);
            cmm.Parameters.AddWithValue("@email", pDependente.email);


            StringBuilder sql = new StringBuilder();

            sql.Append("CALL updateDependente(@idPessoa, @idDependente, @idEscola, @nome,@nacionalidade,@naturalidade,@estadoNaturalidade,@dataNascimento,");
            sql.Append("@estadoCivil,@cpf,@rg,@tituloDeEleitor,@zona,@secao,@endereco,@numero,@bairro,@cidade,@estado,@cep,@sexo,@observacoes,@parentesco,@religiao,@email)");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);

            //update telefones

            TelefonesRepositorio.Delete(pDependente);

            TelefonesRepositorio.Create(pDependente, pDependente.idPessoa);

            //update religioes

            ReligioesRepositorio.Delete(pDependente);

            ReligioesRepositorio.Create(pDependente, pDependente.idPessoa);
        }

        /// <summary>
        /// Metodo para inserir um novo Dependente. Recebe como parametro um objeto do tipo Dependentes.
        /// </summary>
        /// <param name="pDependenteNaoTratado">Objeto Dependentes.</param>
        public static void Create(Dependentes pDependenteNaoTratado)
        {
            MySqlCommand cmm = new MySqlCommand();
            MySqlCommand cmm2 = new MySqlCommand();

            Dependentes pDependente = Utilitarios.DependentesUtil.ToLowerDependente(pDependenteNaoTratado);

            string formatForMySql = pDependente.dataNascimento.ToString("yyyy-MM-dd");
            DateTime dateValue = DateTime.Parse(formatForMySql);

            //insert pessoa

            cmm.Parameters.AddWithValue("@nome", pDependente.nome);
            cmm.Parameters.AddWithValue("@nacionalidade", pDependente.nacionalidade);
            cmm.Parameters.AddWithValue("@naturalidade", pDependente.naturalidade);
            cmm.Parameters.AddWithValue("@estadoNaturalidade", pDependente.estadoNaturalidade);
            cmm.Parameters.AddWithValue("@dataNascimento", dateValue);
            cmm.Parameters.AddWithValue("@estadoCivil", pDependente.estadoCivil);
            cmm.Parameters.AddWithValue("@cpf", pDependente.cpf);
            cmm.Parameters.AddWithValue("@rg", pDependente.rg);
            cmm.Parameters.AddWithValue("@tituloDeEleitor", pDependente.tituloDeEleitor);
            cmm.Parameters.AddWithValue("@zona", pDependente.zona);
            cmm.Parameters.AddWithValue("@secao", pDependente.secao);
            cmm.Parameters.AddWithValue("@endereco", pDependente.endereco);
            cmm.Parameters.AddWithValue("@numero", pDependente.numero);
            cmm.Parameters.AddWithValue("@bairro", pDependente.bairro);
            cmm.Parameters.AddWithValue("@cidade", pDependente.cidade);
            cmm.Parameters.AddWithValue("@estado", pDependente.estado);
            cmm.Parameters.AddWithValue("@cep", pDependente.cep);
            cmm.Parameters.AddWithValue("@sexo", pDependente.sexo);
            cmm.Parameters.AddWithValue("@observacoes", pDependente.observacoes);
            cmm.Parameters.AddWithValue("@email", pDependente.email);

            StringBuilder sql = new StringBuilder();

            sql.Append("CALL insertPessoa(@nome,@nacionalidade,@naturalidade,@estadoNaturalidade,@dataNascimento,");
            sql.Append("@estadoCivil,@cpf,@rg,@tituloDeEleitor,@zona,@secao,@endereco,@numero,@bairro,@cidade,@estado,@cep,@sexo,@observacoes,@email)");

            cmm.CommandText = sql.ToString();

            int idReturn = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            //insert associado

            cmm2.Parameters.AddWithValue("@idPessoa", idReturn);
            cmm2.Parameters.AddWithValue("@idEscola", pDependente.escola.idEscola);
            cmm2.Parameters.AddWithValue("@idAssociado", pDependente.associado.idAssociado);
            cmm2.Parameters.AddWithValue("@parentesco", pDependente.parentesco);

            if (idReturn != 0)
            {
                StringBuilder sql2 = new StringBuilder();

                sql2.Append("CALL InsertDependente (@idAssociado, @idEscola, @idPessoa, @parentesco)");

                cmm2.CommandText = sql2.ToString();

                MySQL.MySQL.MySQL.ExecuteQuery(cmm2);
            }

            //insert Telefones

            TelefonesRepositorio.Create(pDependente, idReturn);

            //insert Religioes

            ReligioesRepositorio.Create(pDependente, idReturn);

        }

        /// <summary>
        /// Metodo para excluir um Dependente. Recebe como parametro um objeto do tipo Dependentes.
        /// </summary>
        /// <param name="pDependenteNaoTratado">Objeto Dependentes.</param>
        public static void Delete(Dependentes pDependente)
        {
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idDependente", pDependente.idDependente);
            cmm.Parameters.AddWithValue("@idPessoa", pDependente.idPessoa);

            StringBuilder sql = new StringBuilder();

            sql.Append("CALL deleteDependente(@idPessoa, @idDependente)");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        /// <summary>
        /// Metodo para buscar dependentes de cada associado. Recebe como parametro o id do associado no formato string. Retorna uma lista do tipo Dependentes.
        /// </summary>
        /// <param name="pIdAssociado">String idAssociado</param>
        /// <returns>Lista de Dependentes.</returns>
        public static List<Dependentes> Get(string pIdAssociado)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idAssociado", pIdAssociado);

            sql.Append("SELECT P.idPessoa, P.nome, P.email, P.nacionalidade, P.naturalidade, P.estadoNaturalidade, P.dataNascimento, P.estadoCivil,");
            sql.Append(" P.cpf, P.rg, P.tituloDeEleitor, P.zona, P.secao, P.endereco, P.numero, P.bairro, P.cidade, P.estado, P.cep, P.sexo,");
            sql.Append(" P.observacoes, D.idDependente, D.parentesco, D.idEscola ");
            sql.Append("FROM Pessoas P inner join Dependentes D ON P.idPessoa = D.idPessoa ");
            sql.Append("WHERE D.idAssociado = @idAssociado");

            cmm.CommandText = sql.ToString();

            List<Dependentes> lista = new List<Dependentes>();
            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Dependentes
                    {
                        idPessoa = Convert.ToInt32(row["idPessoa"]),
                        nome = (string)row["nome"],
                        nacionalidade = (string)row["nacionalidade"],
                        naturalidade = (string)row["naturalidade"],
                        estadoNaturalidade = (string)row["estadoNaturalidade"],
                        dataNascimento = (DateTime)row["dataNascimento"],
                        estadoCivil = (string)row["estadoCivil"],
                        cpf = (string)row["cpf"],
                        rg = (string)row["rg"],
                        tituloDeEleitor = row.IsNull("tituloDeEleitor") ? "" : (string)row["tituloDeEleitor"],
                        zona = row.IsNull("zona") ? "" : (string)row["zona"],
                        secao = row.IsNull("secao") ? "" : (string)row["secao"],
                        endereco = (string)row["endereco"],
                        numero = (string)row["numero"],
                        bairro = (string)row["bairro"],
                        cidade = (string)row["cidade"],
                        estado = (string)row["estado"],
                        cep = (string)row["cep"],
                        sexo = Convert.ToChar(row["sexo"]),
                        observacoes = row.IsNull("observacoes") ? "" : (string)row["observacoes"],
                        email = row.IsNull("email") ? "" : (string)row["email"],
                        religiao = ReligioesRepositorio.GetOne(Convert.ToInt32(row["idPessoa"])),
                        telefones = TelefonesRepositorio.Get(Convert.ToInt32(row["idPessoa"])),
                        idDependente = Convert.ToInt32(row["idDependente"]),
                        associado = AssociadosRepositorio.GetOne(pIdAssociado),
                        parentesco = (string)row["parentesco"],
                        escola = EscolasRepositorio.GetOne(Convert.ToInt32(row["idEscola"]))
                    }
                );
            }

            dt.Dispose();

            List<Dependentes> listaTratada = DependentesUtil.ToFirstUpper(lista);

            return listaTratada;
        }

        /// <summary>
        /// Metodo para buscar dependentes de cada associado. Recebe como parametro o id do associado no formato int. Retorna uma lista do tipo Dependentes.
        /// </summary>
        /// <param name="pIdAssociado">Int idAssociado.</param>
        /// <returns>Lista de Dependentes.</returns>
        public static List<Dependentes> Get(int pIdAssociado)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idAssociado", pIdAssociado);

            sql.Append("SELECT P.idPessoa, P.nome, P.email, P.nacionalidade, P.naturalidade, P.estadoNaturalidade, P.dataNascimento, P.estadoCivil,");
            sql.Append(" P.cpf, P.rg, P.tituloDeEleitor, P.zona, P.secao, P.endereco, P.numero, P.bairro, P.cidade, P.estado, P.cep, P.sexo,");
            sql.Append(" P.observacoes, D.idDependente, D.parentesco, D.idEscola ");
            sql.Append("FROM Pessoas P inner join Dependentes D ON P.idPessoa = D.idPessoa ");
            sql.Append("WHERE D.idAssociado = @idAssociado");

            cmm.CommandText = sql.ToString();

            List<Dependentes> lista = new List<Dependentes>();
            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Dependentes
                    {
                        idPessoa = Convert.ToInt32(row["idPessoa"]),
                        nome = (string)row["nome"],
                        nacionalidade = (string)row["nacionalidade"],
                        naturalidade = (string)row["naturalidade"],
                        estadoNaturalidade = (string)row["estadoNaturalidade"],
                        dataNascimento = (DateTime)row["dataNascimento"],
                        estadoCivil = (string)row["estadoCivil"],
                        cpf = (string)row["cpf"],
                        rg = (string)row["rg"],
                        tituloDeEleitor = row.IsNull("tituloDeEleitor") ? "" : (string)row["tituloDeEleitor"],
                        zona = row.IsNull("zona") ? "" : (string)row["zona"],
                        secao = row.IsNull("secao") ? "" : (string)row["secao"],
                        endereco = (string)row["endereco"],
                        numero = (string)row["numero"],
                        bairro = (string)row["bairro"],
                        cidade = (string)row["cidade"],
                        estado = (string)row["estado"],
                        cep = (string)row["cep"],
                        sexo = Convert.ToChar(row["sexo"]),
                        observacoes = row.IsNull("observacoes") ? "" : (string)row["observacoes"],
                        email = row.IsNull("email") ? "" : (string)row["email"],
                        religiao = ReligioesRepositorio.GetOne(Convert.ToInt32(row["idPessoa"])),
                        telefones = TelefonesRepositorio.Get(Convert.ToInt32(row["idPessoa"])),
                        idDependente = Convert.ToInt32(row["idDependente"]),
                        associado = AssociadosRepositorio.GetOne(pIdAssociado),
                        parentesco = (string)row["parentesco"],
                        escola = EscolasRepositorio.GetOne(Convert.ToInt32(row["idEscola"]))
                    }
                );
            }

            dt.Dispose();

            List<Dependentes> listaTratada = DependentesUtil.ToFirstUpper(lista);

            return listaTratada;
        }

        /// <summary>
        /// Metodo para buscar um dependente. Recebe como parametro o id do dependente no formato string. Retorna um objeto do tipo Dependentes.
        /// </summary>
        /// <param name="pIdDependente">String idDependente.</param>
        /// <returns>Objeto Dependentes.</returns>
        public static Dependentes GetOne(string pIdDependente)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idDependente", pIdDependente);

            sql.Append("SELECT P.idPessoa, P.nome, P.email, P.nacionalidade, P.naturalidade, P.estadoNaturalidade, P.dataNascimento, P.estadoCivil,");
            sql.Append(" P.cpf, P.rg, P.tituloDeEleitor, P.zona, P.secao, P.endereco, P.numero, P.bairro, P.cidade, P.estado, P.cep, P.sexo,");
            sql.Append(" P.observacoes, D.idDependente, D.parentesco, D.idEscola, D.idAssociado ");
            sql.Append("FROM Dependentes D inner join Pessoas P ON D.idPessoa = P.idPessoa ");
            sql.Append(" WHERE idDependente = @idDependente");

            cmm.CommandText = sql.ToString();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                dependente = new Dependentes
                {
                    idPessoa = Convert.ToInt32(row["idPessoa"]),
                    nome = (string)row["nome"],
                    nacionalidade = (string)row["nacionalidade"],
                    naturalidade = (string)row["naturalidade"],
                    estadoNaturalidade = (string)row["estadoNaturalidade"],
                    dataNascimento = (DateTime)row["dataNascimento"],
                    estadoCivil = (string)row["estadoCivil"],
                    cpf = (string)row["cpf"],
                    rg = (string)row["rg"],
                    tituloDeEleitor = row.IsNull("tituloDeEleitor") ? "" : (string)row["tituloDeEleitor"],
                    zona = row.IsNull("zona") ? "" : (string)row["zona"],
                    secao = row.IsNull("secao") ? "" : (string)row["secao"],
                    endereco = (string)row["endereco"],
                    numero = (string)row["numero"],
                    bairro = (string)row["bairro"],
                    cidade = (string)row["cidade"],
                    estado = (string)row["estado"],
                    cep = (string)row["cep"],
                    sexo = Convert.ToChar(row["sexo"]),
                    observacoes = row.IsNull("observacoes") ? "" : (string)row["observacoes"],
                    email = row.IsNull("email") ? "" : (string)row["email"],
                    religiao = ReligioesRepositorio.GetOne(Convert.ToInt32(row["idPessoa"])),
                    telefones = TelefonesRepositorio.Get(Convert.ToInt32(row["idPessoa"])),
                    idDependente = Convert.ToInt32(row["idDependente"]),
                    associado = AssociadosRepositorio.GetOne(Convert.ToInt32(row["idAssociado"])),
                    parentesco = (string)row["parentesco"],
                    escola = EscolasRepositorio.GetOne(Convert.ToInt32(row["idEscola"]))
                };
            }

            dt.Dispose();

            Dependentes dependenteTratado = DependentesUtil.ToFirstUpper(dependente);

            return dependenteTratado;
        }

        /// <summary>
        /// Metodo para buscar dependentes aniversariantes do mes atual. Retorna uma lista do tipo Dependentes.
        /// </summary>
        /// <returns>Lista de Dependentes aniversariantes.</returns>
        public static List<Dependentes> GetAniversariantes()
        {
            List<Dependentes> lista = new List<Dependentes>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT P.nome, P.dataNascimento, P.email ");
            sql.Append("FROM Dependentes D inner join Pessoas P ON D.idPessoa = P.idPessoa ");
            sql.Append("WHERE Month(dataNascimento) = Month(Now());");

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(sql.ToString());

            foreach (DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Dependentes
                    {
                        nome = (string)row["nome"],
                        dataNascimento = (DateTime)row["dataNascimento"],
                        email = row.IsNull("email") ? "" : (string)row["email"]
                    }
                );
            }

            dt.Dispose();

            List<Dependentes> listaTratada = DependentesUtil.ToFirstUpperAniver(lista);

            return listaTratada;

        }

        /// <summary>
        /// Metodo para buscar dependentes por escola. Recebe como parametro o id da escola no formato int. Retorna uma lista do tipo Dependentes.
        /// </summary>
        /// <param name="pIdEscola">Int idEscola</param>
        /// <returns>Lista de Dependentes por escola.</returns>
        public static List<Dependentes> GetDependentePorEscola(int pIdEscola)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idEscola", pIdEscola);

            sql.Append("SELECT P.idPessoa, P.nome, P.email, P.nacionalidade, P.naturalidade, P.estadoNaturalidade, P.dataNascimento, P.estadoCivil,");
            sql.Append(" P.cpf, P.rg, P.tituloDeEleitor, P.zona, P.secao, P.endereco, P.numero, P.bairro, P.cidade, P.estado, P.cep, P.sexo,");
            sql.Append(" P.observacoes, D.idDependente, D.parentesco, D.idEscola, D.idAssociado ");
            sql.Append("FROM Dependentes D inner join Pessoas P ON D.idPessoa = P.idPessoa ");
            sql.Append(" WHERE D.idEscola = @idEscola");

            cmm.CommandText = sql.ToString();

            List<Dependentes> lista = new List<Dependentes>();
            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Dependentes
                    {
                        idPessoa = Convert.ToInt32(row["idPessoa"]),
                        nome = (string)row["nome"],
                        nacionalidade = (string)row["nacionalidade"],
                        naturalidade = (string)row["naturalidade"],
                        estadoNaturalidade = (string)row["estadoNaturalidade"],
                        dataNascimento = (DateTime)row["dataNascimento"],
                        estadoCivil = (string)row["estadoCivil"],
                        cpf = (string)row["cpf"],
                        rg = (string)row["rg"],
                        tituloDeEleitor = row.IsNull("tituloDeEleitor") ? "" : (string)row["tituloDeEleitor"],
                        zona = row.IsNull("zona") ? "" : (string)row["zona"],
                        secao = row.IsNull("secao") ? "" : (string)row["secao"],
                        endereco = (string)row["endereco"],
                        numero = (string)row["numero"],
                        bairro = (string)row["bairro"],
                        cidade = (string)row["cidade"],
                        estado = (string)row["estado"],
                        cep = (string)row["cep"],
                        sexo = Convert.ToChar(row["sexo"]),
                        observacoes = row.IsNull("observacoes") ? "" : (string)row["observacoes"],
                        email = row.IsNull("email") ? "" : (string)row["email"],
                        religiao = ReligioesRepositorio.GetOne(Convert.ToInt32(row["idPessoa"])),
                        telefones = TelefonesRepositorio.Get(Convert.ToInt32(row["idPessoa"])),
                        idDependente = Convert.ToInt32(row["idDependente"]),
                        associado = AssociadosRepositorio.GetOne(Convert.ToInt32(row["idAssociado"])),
                        parentesco = (string)row["parentesco"],
                        escola = EscolasRepositorio.GetOne(Convert.ToInt32(row["idEscola"]))
                    }
                );
            }

            dt.Dispose();

            List<Dependentes> listaTratada = DependentesUtil.ToFirstUpper(lista);

            return listaTratada;
        }

        /// <summary>
        /// Metodo para buscar todos dependentes eleitores cadastrados. Retorna uma lista do tipo Dependentes.
        /// </summary>
        /// <returns>Lista de Dependentes eleitores.</returns>
        public static List<Dependentes> GetEleitores()
        {
            List<Dependentes> lista = new List<Dependentes>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT P.nome, P.tituloDeEleitor, P.zona, P.secao ");
            sql.Append("FROM Dependentes D inner join Pessoas P ON D.idPessoa = P.idPessoa ");
            sql.Append("WHERE  P.tituloDeEleitor is not null and P.zona is not null and P.secao is not null");

            MySqlDataReader dataReader = MySQL.MySQL.MySQL.getLista(sql.ToString());

            try
            {

                while (dataReader.Read())
                {
                    lista.Add(
                                new Dependentes
                                {
                                    nome = dataReader.GetString(dataReader.GetOrdinal("nome")),
                                    tituloDeEleitor = dataReader.IsDBNull(dataReader.GetOrdinal("tituloDeEleitor")) ? "" : dataReader.GetString(dataReader.GetOrdinal("tituloDeEleitor")),
                                    zona = dataReader.IsDBNull(dataReader.GetOrdinal("zona")) ? "" : dataReader.GetString(dataReader.GetOrdinal("zona")),
                                    secao = dataReader.IsDBNull(dataReader.GetOrdinal("secao")) ? "" : dataReader.GetString(dataReader.GetOrdinal("secao"))
                                }
                        );
                }

                dataReader.Dispose();

                List<Dependentes> listaTratada = DependentesUtil.ToFirstUpperEleitores(lista);

                return listaTratada;
            }
            catch (MySqlException tw)
            {
                dataReader.Dispose();
                throw tw;
            }
        }
    }
}