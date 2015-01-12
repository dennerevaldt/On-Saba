using Associação_Ulbra_Torres.Models.Entidade;
using Associação_Ulbra_Torres.Models.Utilitarios;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Repositorio
{
    public class AssociadosRepositorio
    {
        public static Associados associado;

        /// <summary>
        /// Metodo para inserir novo Associado. Recebe como parametro um objeto do tipo Associados.
        /// </summary>
        /// <param name="pAssociadoNaoTratado">Objeto Associados.</param>
        public static void Create(Associados pAssociadoNaoTratado)
        {
            MySqlCommand cmm = new MySqlCommand();
            MySqlCommand cmm2 = new MySqlCommand();


            //insert pessoa

            Associados pAssociado = Utilitarios.AssociadosUtil.ToLowerAssociado(pAssociadoNaoTratado);

            string formatForMySql = pAssociado.dataNascimento.ToString("yyyy-MM-dd HH:mm");
            DateTime dateValue = DateTime.Parse(formatForMySql);

            cmm.Parameters.AddWithValue("@nome", pAssociado.nome);
            cmm.Parameters.AddWithValue("@nacionalidade", pAssociado.nacionalidade);
            cmm.Parameters.AddWithValue("@naturalidade", pAssociado.naturalidade);
            cmm.Parameters.AddWithValue("@estadoNaturalidade", pAssociado.estadoNaturalidade);
            cmm.Parameters.AddWithValue("@dataNascimento", dateValue);
            cmm.Parameters.AddWithValue("@estadoCivil", pAssociado.estadoCivil);
            cmm.Parameters.AddWithValue("@cpf", pAssociado.cpf);
            cmm.Parameters.AddWithValue("@rg", pAssociado.rg);
            cmm.Parameters.AddWithValue("@tituloDeEleitor", pAssociado.tituloDeEleitor);
            cmm.Parameters.AddWithValue("@zona", pAssociado.zona);
            cmm.Parameters.AddWithValue("@secao", pAssociado.secao);
            cmm.Parameters.AddWithValue("@endereco", pAssociado.endereco);
            cmm.Parameters.AddWithValue("@numero", pAssociado.numero);
            cmm.Parameters.AddWithValue("@bairro", pAssociado.bairro);
            cmm.Parameters.AddWithValue("@cidade", pAssociado.cidade);
            cmm.Parameters.AddWithValue("@estado", pAssociado.estado);
            cmm.Parameters.AddWithValue("@cep", pAssociado.cep);
            cmm.Parameters.AddWithValue("@sexo", pAssociado.sexo);
            cmm.Parameters.AddWithValue("@observacoes", pAssociado.observacoes);
            cmm.Parameters.AddWithValue("@email", pAssociado.email);

            StringBuilder sql = new StringBuilder();

            sql.Append("CALL insertPessoa(@nome,@nacionalidade,@naturalidade,@estadoNaturalidade,@dataNascimento,");
            sql.Append("@estadoCivil,@cpf,@rg,@tituloDeEleitor,@zona,@secao,@endereco,@numero,@bairro,@cidade,@estado,@cep,@sexo,@observacoes,@email)");

            cmm.CommandText = sql.ToString();

            int idReturn = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            //insert associado

            cmm2.Parameters.AddWithValue("@idPessoa", idReturn);
            cmm2.Parameters.AddWithValue("@tipoResidencia", pAssociado.tipoResidencia);

            if (idReturn != 0)
            {
                StringBuilder sql2 = new StringBuilder();

                sql2.Append("CALL InsertAssociado(@idPessoa, @tipoResidencia)");

                cmm2.CommandText = sql2.ToString();

                MySQL.MySQL.MySQL.ExecuteQuery(cmm2);
            }

            //insert telefones

            TelefonesRepositorio.Create(pAssociado, idReturn);

            //insert religioes

            ReligioesRepositorio.Create(pAssociado, idReturn);
            
        }

        /// <summary>
        /// Metodo para editar os dados de um Associado. Recebe como parametro um objeto do tipo Associados.
        /// </summary>
        /// <param name="pAssociadoNaoTratado">Objeto Associados.</param>
        public static void Edit(Associados pAssociadoNaoTratado)
        {
            MySqlCommand cmm = new MySqlCommand();
            Associados pAssociado = AssociadosUtil.ToLowerAssociado(pAssociadoNaoTratado);

            string formatForMySql = pAssociado.dataNascimento.ToString("yyyy-MM-dd");
            DateTime dateValue = DateTime.Parse(formatForMySql);

            cmm.Parameters.AddWithValue("@idPessoa", pAssociado.idPessoa);
            cmm.Parameters.AddWithValue("@idAssociado", pAssociado.idAssociado);
            cmm.Parameters.AddWithValue("@nome", pAssociado.nome);
            cmm.Parameters.AddWithValue("@nacionalidade", pAssociado.nacionalidade);
            cmm.Parameters.AddWithValue("@naturalidade", pAssociado.naturalidade);
            cmm.Parameters.AddWithValue("@estadoNaturalidade", pAssociado.estadoNaturalidade);
            cmm.Parameters.AddWithValue("@dataNascimento", dateValue);
            cmm.Parameters.AddWithValue("@estadoCivil", pAssociado.estadoCivil);
            cmm.Parameters.AddWithValue("@cpf", pAssociado.cpf);
            cmm.Parameters.AddWithValue("@rg", pAssociado.rg);
            cmm.Parameters.AddWithValue("@tituloDeEleitor", pAssociado.tituloDeEleitor);
            cmm.Parameters.AddWithValue("@zona", pAssociado.zona);
            cmm.Parameters.AddWithValue("@secao", pAssociado.secao);
            cmm.Parameters.AddWithValue("@endereco", pAssociado.endereco);
            cmm.Parameters.AddWithValue("@numero", pAssociado.numero);
            cmm.Parameters.AddWithValue("@bairro", pAssociado.bairro);
            cmm.Parameters.AddWithValue("@cidade", pAssociado.cidade);
            cmm.Parameters.AddWithValue("@estado", pAssociado.estado);
            cmm.Parameters.AddWithValue("@cep", pAssociado.cep);
            cmm.Parameters.AddWithValue("@sexo", pAssociado.sexo);
            cmm.Parameters.AddWithValue("@observacoes", pAssociado.observacoes);
            cmm.Parameters.AddWithValue("@tipoResidencia", pAssociado.tipoResidencia);
            cmm.Parameters.AddWithValue("@email", pAssociado.email);
            cmm.Parameters.AddWithValue("@religiao", pAssociado.religiao.nome);

            StringBuilder sql = new StringBuilder();

            sql.Append("CALL updateAssociado(@idPessoa, @idAssociado, @nome,@nacionalidade,@naturalidade,@estadoNaturalidade,@dataNascimento,");
            sql.Append("@estadoCivil,@cpf,@rg,@tituloDeEleitor,@zona,@secao,@endereco,@numero,@bairro,@cidade,@estado,@cep,@sexo,@observacoes,@tipoResidencia,@email,@religiao)");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
 
            //update telefones

            TelefonesRepositorio.Delete(pAssociado);

            TelefonesRepositorio.Create(pAssociado, pAssociado.idPessoa);

            //update religioes

            ReligioesRepositorio.Delete(pAssociado);

            ReligioesRepositorio.Create(pAssociado, pAssociado.idPessoa);
        }

        /// <summary>
        /// Metodo para deletar um Associado. Recebe como parametro um objeto do tipo Associados.
        /// </summary>
        /// <param name="pAssociado">Objeto Associados.</param>
        public static void Delete(Associados pAssociado)
        {
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idAssociado", pAssociado.idAssociado);
            cmm.Parameters.AddWithValue("@idPessoa", pAssociado.idPessoa);

            StringBuilder sql = new StringBuilder();

            sql.Append("CALL deleteAssociado(@idPessoa, @idAssociado)");
            cmm.CommandText = sql.ToString();

            if (pAssociado.dependentes != null)
            {
                foreach (Dependentes dependente in pAssociado.dependentes)
                {
                    DependentesRepositorio.Delete(dependente);
                }
            }

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        /// <summary>
        /// Metodo para buscar todos Associados cadastrados. Retorna uma lista de Associados.
        /// </summary>
        /// <returns>Lista de Associados.</returns>
        public static List<Associados> Get()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * ");
            sql.Append("FROM pessoas P inner join associados A ON P.idPessoa = A.idPessoa ");

            List<Associados> lista = new List<Associados>();
            DataTable dt = MySQL.MySQL.MySQL.getDataTable(sql.ToString());

            foreach (DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Associados
                    {
                        idAssociado = Convert.ToInt32(row["idAssociado"]),
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
                        tipoResidencia = (string)row["tipoResidencia"],
                        email = row.IsNull("email") ? "" : (string)row["email"],
                        religiao = ReligioesRepositorio.GetOne(Convert.ToInt32(row["idPessoa"])),
                        telefones = TelefonesRepositorio.Get(Convert.ToInt32(row["idPessoa"]))
                    }
                );
            }

            List<Associados> listaTratada = AssociadosUtil.ToFirstUpper(lista);

            dt.Dispose();

            return listaTratada;
        }

        /// <summary>
        /// Metodo para buscar Associados pelo nome. Recebe como parametro um nome no formato de string. Retorna um objeto Associados.
        /// </summary>
        /// <param name="pNome">String nome.</param>
        /// <returns>Objeto Associados.</returns>
        public static List<Associados> Get(string pNome)
        {
            if (pNome == "")
            {
                pNome = "null";
            }

            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@pNome", "%" + pNome + "%");

            sql.Append("SELECT * ");
            sql.Append("FROM pessoas P inner join associados A ON P.idPessoa = A.idPessoa ");
            sql.Append("WHERE P.nome LIKE @pNome ");

            cmm.CommandText = sql.ToString();

            List<Associados> lista = new List<Associados>();
            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Associados
                    {
                        idAssociado = Convert.ToInt32(row["idAssociado"]),
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
                        tipoResidencia = (string)row["tipoResidencia"],
                        email = row.IsNull("email") ? "" : (string)row["email"],
                        religiao = ReligioesRepositorio.GetOne(Convert.ToInt32(row["idPessoa"])),
                        telefones = TelefonesRepositorio.Get(Convert.ToInt32(row["idPessoa"]))
                    }
                );
            }

            List<Associados> listaTratada = AssociadosUtil.ToFirstUpper(lista);

            dt.Dispose();

            return listaTratada;
        }

        /// <summary>
        /// Metodo para buscar um associado. Recebe como parametro o id do associado no formato string. Retorna um objeto Associados.
        /// </summary>
        /// <param name="pIdAssociado">String idAssociado.</param>
        /// <returns>Objeto Associados.</returns>
        public static Associados GetOne(string pIdAssociado)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idAssociado", pIdAssociado);

            sql.Append("SELECT * ");
            sql.Append("FROM Associados A inner join Pessoas P ON A.idPessoa = P.idPessoa ");
            sql.Append(" WHERE idAssociado = @idAssociado");

            cmm.CommandText = sql.ToString();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                associado = new Associados
                            {
                                idAssociado = Convert.ToInt32(row["idAssociado"]),
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
                                tipoResidencia = (string)row["tipoResidencia"],
                                email = row.IsNull("email") ? "" : (string)row["email"],
                                religiao = ReligioesRepositorio.GetOne(Convert.ToInt32(row["idPessoa"])),
                                telefones = TelefonesRepositorio.Get(Convert.ToInt32(row["idPessoa"])),
                                dependentes = DependentesRepositorio.Get(Convert.ToInt32(row["idAssociado"]))
                            };    
            }

            dt.Dispose();

            Associados associadoTratado = AssociadosUtil.ToFirstUpper(associado);

            return associadoTratado;
        }

        /// <summary>
        /// Metodo para buscar um associado. Recebe como parametro o id do associado no formato int. Retorna um objeto Associados.
        /// </summary>
        /// <param name="pIdAssociado">Int idAssociado.</param>
        /// <returns>Objeto Associados.</returns>
        public static Associados GetOne(int pIdAssociado)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idAssociado", pIdAssociado);

            sql.Append("SELECT * ");
            sql.Append("FROM Associados A inner join Pessoas P ON A.idPessoa = P.idPessoa ");
            sql.Append(" WHERE idAssociado = @idAssociado");

            cmm.CommandText = sql.ToString();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                associado = new Associados
                {
                    idAssociado = Convert.ToInt32(row["idAssociado"]),
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
                    tipoResidencia = (string)row["tipoResidencia"],
                    email = row.IsNull("email") ? "" : (string)row["email"],
                    religiao = ReligioesRepositorio.GetOne(Convert.ToInt32(row["idPessoa"])),
                    telefones = TelefonesRepositorio.Get(Convert.ToInt32(row["idPessoa"]))
                };
            }

            dt.Dispose();

            Associados associadoTratado = AssociadosUtil.ToFirstUpper(associado);

            return associadoTratado;
        }

        /// <summary>
        /// Metodo contador de associados cadastrados. Retorna um int com numero total de associados cadastrados.
        /// </summary>
        /// <returns>Numero total de associados.</returns>
        public static int GetContador()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Associados");

            cmm.CommandText = sql.ToString();

            int cont = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return cont;
        }

        /// <summary>
        /// Metodo para buscar todos associados aniversariantes do mes. Retorna uma lista de Associados.
        /// </summary>
        /// <returns>Lista de Associados.</returns>
        public static List<Associados> GetAniversariantes()
        {
            List<Associados> lista = new List<Associados>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT P.nome, P.dataNascimento, P.email ");
            sql.Append("FROM Associados A inner join Pessoas P ON A.idPessoa = P.idPessoa ");
            sql.Append("WHERE Month(dataNascimento) = Month(Now());");

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(sql.ToString());

            foreach (DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Associados
                    {
                        nome = (string)row["nome"],
                        dataNascimento = (DateTime)row["dataNascimento"],
                        email = row.IsNull("email") ? "" : (string)row["email"],
                    }
                );
            }

            dt.Dispose();

            List<Associados> listaTratada = AssociadosUtil.ToFirstUpperAniver(lista);

            return listaTratada;
           
        }

        /// <summary>
        /// Metodo para buscar todos associados eleitores. Retorna uma lista de Associados.
        /// </summary>
        /// <returns>Lista de Associados.</returns>
        public static List<Associados> GetEleitores()
        {
            List<Associados> lista = new List<Associados>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT P.nome, P.tituloDeEleitor, P.zona, P.secao ");
            sql.Append("FROM Associados A inner join Pessoas P ON A.idPessoa = P.idPessoa ");
            sql.Append("WHERE  P.tituloDeEleitor is not null and P.zona is not null and P.secao is not null");

            MySqlDataReader dataReader = MySQL.MySQL.MySQL.getLista(sql.ToString());

            try
            {

                while (dataReader.Read())
                {
                    lista.Add(
                                new Associados
                                {
                                    nome = dataReader.GetString(dataReader.GetOrdinal("nome")),
                                    tituloDeEleitor = dataReader.IsDBNull(dataReader.GetOrdinal("tituloDeEleitor")) ? "" : dataReader.GetString(dataReader.GetOrdinal("tituloDeEleitor")),
                                    zona = dataReader.IsDBNull(dataReader.GetOrdinal("zona")) ? "" : dataReader.GetString(dataReader.GetOrdinal("zona")),
                                    secao = dataReader.IsDBNull(dataReader.GetOrdinal("secao")) ? "" : dataReader.GetString(dataReader.GetOrdinal("secao"))
                                }
                        );
                }

                dataReader.Dispose();

                List<Associados> listaTratada = AssociadosUtil.ToFirstUpperEleitores(lista);

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