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
    public class TelefonesRepositorio
    {
        #region Metodos da Classe Associados para Insert e Delete de Telefones

        /// <summary>
        /// Metodo para inserir novos telefones de Associados. Recebe como parametro um objeto do tipo Associados e int id da pessoa relacionada ao associado.
        /// </summary>
        /// <param name="pAssociado">Objeto Associados.</param>
        /// <param name="pIdPessoa">Int idPessoa.</param>
        public static void Create(Associados pAssociado, int pIdPessoa)
        {
            if (pAssociado.telefones != null)
            {
                foreach (Telefones telefone in pAssociado.telefones)
                {
                    if (telefone.numero != null)
                    {
                        StringBuilder sql = new StringBuilder();
                        MySqlCommand cmm = new MySqlCommand();

                        cmm.Parameters.AddWithValue("@idPessoa", pIdPessoa);
                        cmm.Parameters.AddWithValue("@tipoNumero", telefone.tipo.ToString());
                        cmm.Parameters.AddWithValue("@numero", telefone.numero.ToString());

                        sql.Append("CALL insertTelefone (@idPessoa,@tipoNumero,@numero) ");

                        cmm.CommandText = sql.ToString();

                        MySQL.MySQL.MySQL.ExecuteQuery(cmm);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo para deletar telefones de Associados. Recebe como parametro um objeto do tipo Associados.
        /// </summary>
        /// <param name="pAssociado">Objeto Associados.</param>
        public static void Delete(Associados pAssociado)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idPessoaTel", pAssociado.idPessoa);

            sql.Append("DELETE FROM telefones ");
            sql.Append("WHERE idPessoa = @idPessoaTel");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }
        
        #endregion

        #region Metodos da Classe Dependentes para Insert e Delete de Telefones

        /// <summary>
        /// Metodo para inserir novos telefones de Dependentes. Recebe como parametro um objeto do tipo Dependentes e int id da pessoa relacionada ao dependente.
        /// </summary>
        /// <param name="pDependente">Objeto Dependentes.</param>
        /// <param name="pIdPessoa">Int idPessoa.</param>
        public static void Create(Dependentes pDependente, int pIdPessoa)
        {
            if (pDependente.telefones != null)
            {
                foreach (Telefones telefone in pDependente.telefones)
                {
                    if (telefone.numero != null)
                    {
                        StringBuilder sql = new StringBuilder();
                        MySqlCommand cmm = new MySqlCommand();

                        cmm.Parameters.AddWithValue("@idPessoa", pIdPessoa);
                        cmm.Parameters.AddWithValue("@tipoNumero", telefone.tipo.ToString());
                        cmm.Parameters.AddWithValue("@numero", telefone.numero.ToString());

                        sql.Append("CALL insertTelefone (@idPessoa,@tipoNumero,@numero) ");

                        cmm.CommandText = sql.ToString();

                        MySQL.MySQL.MySQL.ExecuteQuery(cmm);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo para deletar telefones de Dependentes. Recebe como parametro um objeto do tipo Dependentes.
        /// </summary>
        /// <param name="pDependente">Objeto Dependentes.</param>
        public static void Delete(Dependentes pDependente)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idPessoaTel", pDependente.idPessoa);

            sql.Append("DELETE FROM telefones ");
            sql.Append("WHERE idPessoa = @idPessoaTel");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }
        
        #endregion

        /// <summary>
        /// Metodo para buscar telefones. Recebe como parametro um int id da pessoa. Retorna uma lista de telefones.
        /// </summary>
        /// <param name="pIdPessoa">Int idPessoa</param>
        /// <returns>Lista de Telefones.</returns>
        public static List<Telefones> Get(int pIdPessoa)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idPessoa", pIdPessoa);

            sql.Append("SELECT idTelefone, tipo, numero ");
            sql.Append("FROM telefones WHERE idPessoa = @idPessoa");

            cmm.CommandText = sql.ToString();

            List<Telefones> lista = new List<Telefones>();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach(DataRow row in dt.Rows)
            {
                lista.Add
                (
                    new Telefones
                    {
                        idTelefone = Convert.ToInt32(row["idTelefone"]),
                        tipo = row.IsNull("tipo") ? "" : (string)row["tipo"],
                        numero = row.IsNull("numero") ? "" : (string)row["numero"]                  
                    }
                );
            }

            dt.Dispose();

            return lista;
        }
    }

}