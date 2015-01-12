using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySQL.MySQL;
using System.Text;
using MySql.Data.MySqlClient;
using Associação_Ulbra_Torres.Models.Entidade;
using System.Data;
using Associação_Ulbra_Torres.Models.Utilitarios;

namespace Associação_Ulbra_Torres.Models.Repositorio
{
    public class EscolasRepositorio
    {
        public static Escolas escola;

        /// <summary>
        /// Metodo para buscar todos escolas cadastradas. Retorna uma lista do tipo Escolas.
        /// </summary>
        /// <returns></returns>
        public static List<Escolas> Get()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * ");
            sql.Append("FROM Escolas");

            List<Escolas> lista = new List<Escolas>();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(sql.ToString());

            foreach (DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Escolas
                    {
                        idEscola = Convert.ToInt32(row["idEscola"]),
                        nomeEscola = (string)row["nome"]
                    }
                );
            }

            dt.Dispose();

            List<Escolas> listaTratada = EscolasUtil.ToFirstUpper(lista);

            return listaTratada;
            
        }

        /// <summary>
        /// Metodo para buscar um objeto do tipo Escolas. Recebe como parametro o id no formato string da escola. Retorna um objeto do tipo Escolas.
        /// </summary>
        /// <param name="pIdEscola">String idEscola</param>
        /// <returns>Objeto Escolas.</returns>
        public static Escolas GetOne(string pIdEscola)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idEscola", pIdEscola);

            sql.Append("SELECT * ");
            sql.Append("FROM Escolas");
            sql.Append(" WHERE idEscola = @idEscola");

            cmm.CommandText = sql.ToString();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                escola = new Escolas
                {
                    idEscola = Convert.ToInt32(row["idEscola"]),
                    nomeEscola = (string)row["nome"]
                };
            }

            dt.Dispose();

            Escolas escolaTratada = EscolasUtil.ToFirstUpper(escola);

            return escolaTratada;

        }

        /// <summary>
        /// Metodo para buscar um objeto do tipo escola. Recebe como parametro o id no formato int32 da escola. Retorna um objeto do tipo Escolas.
        /// </summary>
        /// <param name="pIdEscola">Int32 idEscola</param>
        /// <returns>Objeto Escolas</returns>
        public static Escolas GetOne(Int32 pIdEscola)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idEscola", pIdEscola);

            sql.Append("SELECT * ");
            sql.Append("FROM Escolas");
            sql.Append(" WHERE idEscola = @idEscola");

            cmm.CommandText = sql.ToString();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                escola = new Escolas
                {
                    idEscola = Convert.ToInt32(row["idEscola"]),
                    nomeEscola = (string)row["nome"]
                };
            }

            dt.Dispose();

            Escolas escolaTratada = EscolasUtil.ToFirstUpper(escola);

            return escolaTratada;

        }

        /// <summary>
        /// Metodo para buscar um objeto do tipo Escolas. Recebe como parametro um objeto do tipo Escolas. Retorna um objeto do tipo Escolas.
        /// </summary>
        /// <param name="pEscola">Objeto Escolas.</param>
        /// <returns>Objeto Escolas.</returns>
        public static Escolas GetOne(Escolas pEscola)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idEscola", pEscola.idEscola);

            sql.Append("SELECT * ");
            sql.Append("FROM Escolas");
            sql.Append(" WHERE idEscola = @idEscola");

            cmm.CommandText = sql.ToString();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                escola = new Escolas
                {
                    idEscola = Convert.ToInt32(row["idEscola"]),
                    nomeEscola = (string)row["nome"]
                };
            }

            dt.Dispose();

            Escolas escolaTratada = EscolasUtil.ToFirstUpper(escola);

            return escolaTratada;

        }

        /// <summary>
        /// Metodo para inserir uma nova escola. Recebe como parametro um objeto do tipo Escolas.
        /// </summary>
        /// <param name="pEscolaNaoTratada">Objeto Escolas.</param>
        public static void Create(Escolas pEscolaNaoTratada)
        {
            MySqlCommand cmm = new MySqlCommand();

            Escolas pEscola = EscolasUtil.ToLowerEscola(pEscolaNaoTratada);

            cmm.Parameters.AddWithValue("@nome", pEscola.nomeEscola);

            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Escolas (nome) ");
            sql.Append("VALUES (@nome)");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        /// <summary>
        /// Metodo para editar uma escola. Recebe como parametro um objeto do tipo Escolas.
        /// </summary>
        /// <param name="pEscolaNaoTratada">Objeto Escolas.</param>
        public static void Edit(Escolas pEscolaNaoTratada)
        {
            MySqlCommand cmm = new MySqlCommand();

            Escolas pEscola = EscolasUtil.ToLowerEscola(pEscolaNaoTratada);

            cmm.Parameters.AddWithValue("@idEscola", pEscola.idEscola);
            cmm.Parameters.AddWithValue("@nome", pEscola.nomeEscola);

            StringBuilder sql = new StringBuilder();
          
            sql.Append("UPDATE Escolas");
            sql.Append(" SET nome = @nome");
            sql.Append(" WHERE idEscola = @idEscola");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm); 
        }

        /// <summary>
        /// Metodo para deletar uma escola. Recebe como parametro um objeto do tipo Escolas.
        /// </summary>
        /// <param name="pEscola">Objeto Escolas.</param>
        public static void Delete(Escolas pEscola)
        {
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idEscola", pEscola.idEscola);

            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM Escolas");
            sql.Append(" WHERE idEscola = @idEscola");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        /// <summary>
        /// Metodo contador de escolas. Retorna int com o numero de escolas cadastradas.
        /// </summary>
        /// <returns>Numero total de escolas.</returns>
        public static int GetContador()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Escolas");

            cmm.CommandText = sql.ToString();

            int cont = MySQL.MySQL.MySQL.ExecuteScalar(cmm);
      
            return cont;
        }

    }
}