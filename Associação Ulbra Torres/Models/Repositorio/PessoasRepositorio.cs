using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Repositorio
{
    public class PessoasRepositorio
    {
        private static int numHomens;
        private static int numMulheres;
        private static int numCriancas;
        private static int numAdultos;
        private static int numIdosos;

        #region Metodos contadores de Mulheres

        /// <summary>
        /// Metodo contador. Retorna int com o numero total de Mulheres cadastradas.
        /// </summary>
        /// <returns></returns>
        public static int NumeroMulheres()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Pessoas ");
            sql.Append("WHERE sexo = \"M\"");

            cmm.CommandText = sql.ToString();

            numMulheres = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return numMulheres;
        }

        /// <summary>
        /// Metodo contador. Retorna int com o numero total de Criancas Mulheres cadastradas.
        /// </summary>
        /// <returns>Numero total de criancas mulheres.</returns>
        public static int NumeroCriancasMulheres()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Pessoas ");
            sql.Append("WHERE Year(Now()) - Year(dataNascimento) <= 12 and sexo = \"M\"");

            cmm.CommandText = sql.ToString();

            numCriancas = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return numCriancas;
        }

        /// <summary>
        /// Metodo contador. Retorna int com o numero total de Mulheres Adultas cadastrados.
        /// </summary>
        /// <returns>Numero total de mulheres adultas.</returns>
        public static int NumeroAdultosMulheres()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Pessoas ");
            sql.Append("WHERE Year(Now()) - Year(dataNascimento) > 12 and Year(Now()) - Year(dataNascimento) <= 50 and sexo = \"M\"");

            cmm.CommandText = sql.ToString();

            numAdultos = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return numAdultos;
        }

        /// <summary>
        /// Metodo contador. Retorna int com o numero total de Mulheres idosas cadastradas.
        /// </summary>
        /// <returns>Numero total de mulheres idosas.</returns>
        public static int NumeroIdososMulheres()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Pessoas ");
            sql.Append("WHERE Year(Now()) - Year(dataNascimento) > 50 and sexo = \"M\"");

            cmm.CommandText = sql.ToString();

            numIdosos = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return numIdosos;
        }

        #endregion

        #region Metodos contadores de Homens

        /// <summary>
        /// Metodo contador. Retorna int com o numero total de Homens cadastrados.
        /// </summary>
        /// <returns>Numero total de homens.</returns>
        public static int NumeroHomens()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Pessoas ");
            sql.Append("WHERE sexo = \"H\"");

            cmm.CommandText = sql.ToString();

            numHomens = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return numHomens;
        }

        /// <summary>
        /// Metodo contador. Retorna int com o numero total de Criancas homens cadastrados.
        /// </summary>
        /// <returns>Numero total de criancas homens.</returns>
        public static int NumeroCriancasHomens()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Pessoas ");
            sql.Append("WHERE Year(Now()) - Year(dataNascimento) <= 12 and sexo = \"H\"");

            cmm.CommandText = sql.ToString();

            numCriancas = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return numCriancas;
        }

        /// <summary>
        /// Metodo contador. Retorna int com o numero total de Homens adultos cadastrados.
        /// </summary>
        /// <returns>Numero total de homens adultos.</returns>
        public static int NumeroAdultosHomens()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Pessoas ");
            sql.Append("WHERE Year(Now()) - Year(dataNascimento) > 12 and Year(Now()) - Year(dataNascimento) <= 50 and sexo = \"H\"");

            cmm.CommandText = sql.ToString();

            numAdultos = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return numAdultos;
        }

        /// <summary>
        /// Metodo contador. Retorna int com o numero total de Homens idosos cadastrados.
        /// </summary>
        /// <returns>Numero total de homens idosos.</returns>
        public static int NumeroIdososHomens()
        {
            MySqlCommand cmm = new MySqlCommand();

            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT COUNT(*) ");
            sql.Append("FROM Pessoas ");
            sql.Append("WHERE Year(Now()) - Year(dataNascimento) > 50 and sexo = \"H\"");

            cmm.CommandText = sql.ToString();

            numIdosos = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return numIdosos;
        }

        #endregion
    }
}