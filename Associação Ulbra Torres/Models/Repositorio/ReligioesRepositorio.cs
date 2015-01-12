using Associação_Ulbra_Torres.Models.Entidade;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Repositorio
{
    public class ReligioesRepositorio
    {
        #region  Metodos da Classe Associados para Insert e Delete de Religioes
        /// <summary>
        /// Metodo para inserir novas religioes de Associados. Recebe como parametro um objeto do tipo Associados e int id da pessoa relacionada ao associado.
        /// </summary>
        /// <param name="pAssociado">Objeto Associados.</param>
        /// <param name="idPessoa">Int idPessoa.</param>
        public static void Create(Associados pAssociado, int idPessoa)
        {
            if (pAssociado.religiao != null)
            {
                if (pAssociado.religiao.nome != null)
                {
                    StringBuilder sql = new StringBuilder();
                    MySqlCommand cmm = new MySqlCommand();

                    cmm.Parameters.AddWithValue("@idPessoa", idPessoa);
                    cmm.Parameters.AddWithValue("@nome", pAssociado.religiao.nome);

                    sql.Append("CALL insertReligiao (@idPessoa, @nome)");

                    cmm.CommandText = sql.ToString();

                    MySQL.MySQL.MySQL.ExecuteQuery(cmm);
                }
            }
        }

        /// <summary>
        /// Metodo para deletar religioes de Associados. Recebe como parametro um objeto do tipo Associados.
        /// </summary>
        /// <param name="pAssociado">Objeto Associados.</param>
        public static void Delete(Associados pAssociado)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idPessoaRel", pAssociado.idPessoa);

            sql.Append("DELETE FROM religioes ");
            sql.Append("WHERE idPessoa = @idPessoaRel");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }
        #endregion

        #region Metodos da Classe Dependentes para Insert e Delete de Religioes

        /// <summary>
        /// Metodo para inserir novas religioes de Dependentes. Recebe como parametro um objeto do tipo Dependentes e int id da pessoa relacionada ao dependente.
        /// </summary>
        /// <param name="pDependente">Objeto Dependentes.</param>
        /// <param name="idPessoa">Int idPessoa.</param>
        public static void Create(Dependentes pDependente, int idPessoa)
        {
            if (pDependente.religiao != null)
            {
                if (pDependente.religiao.nome != null)
                {
                    StringBuilder sql = new StringBuilder();
                    MySqlCommand cmm = new MySqlCommand();

                    cmm.Parameters.AddWithValue("@idPessoa", idPessoa);
                    cmm.Parameters.AddWithValue("@nome", pDependente.religiao.nome);

                    sql.Append("CALL insertReligiao (@idPessoa, @nome)");

                    cmm.CommandText = sql.ToString();

                    MySQL.MySQL.MySQL.ExecuteQuery(cmm);
                }
            }
        }

        /// <summary>
        /// Metodo para deletar religioes de Dependentes. Recebe como parametro um objeto do tipo Dependentes.
        /// </summary>
        /// <param name="pDependente">Objeto Dependentes.</param>
        public static void Delete(Dependentes pDependente)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idPessoaRel", pDependente.idPessoa);

            sql.Append("DELETE FROM religioes ");
            sql.Append("WHERE idPessoa = @idPessoaRel");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        #endregion

        /// <summary>
        /// Metodo para buscar religiao de uma pessoa especifica. Recebe como parametro o id da pessoa. Retorna uma religiao.
        /// </summary>
        /// <param name="pIdPessoa">Int idPessoa</param>
        /// <returns>Objeto Religioes.</returns>
        public static Religioes GetOne(int pIdPessoa)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idPessoa", pIdPessoa);

            sql.Append("SELECT nome ");
            sql.Append("FROM religioes WHERE idPessoa = @idPessoa");

            cmm.CommandText = sql.ToString();

            Religioes religiao = new Religioes();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                religiao = new Religioes
                {
                    nome = row.IsNull("nome") ? "" : (string)row["nome"]
                };

            }

            dt.Dispose();

            return religiao;
        }
     }
}