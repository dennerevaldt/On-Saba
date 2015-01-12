using Associação_Ulbra_Torres.Models.Entidade;
using Associação_Ulbra_Torres.Models.Utilitarios;
using CryptSharp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Repositorio
{
    public class UsuariosRepositorio
    {
        public static Usuarios user;

        /// <summary>
        /// Metodo para buscar um usuario e validar seu login. Recebe como parametro um objeto tipo Usuarios. Se existente retorna um objeto do tipo Usuarios com os dados do mesmo.
        /// </summary>
        /// <param name="pUser">Objeto Usuarios.</param>
        /// <returns>Objeto do tipo Usuarios.</returns>
        public static Usuarios GetUser(Usuarios pUser)
        {
            Usuarios usuarioEmail = GetUserEmail(pUser.email);

            bool checkSenha = Checar(pUser.senha,usuarioEmail.senha);

            Usuarios usuarioReturn = new Usuarios();

            if (checkSenha && usuarioEmail.verificacao == "V")
            {
                usuarioReturn = UsuariosUtil.ToFirstUpper(usuarioEmail);
            }
            else
            {
                usuarioReturn = null;
            }

            return usuarioReturn;
            
        }

        /// <summary>
        /// Metodo para buscar um usuario. Recebe como parametro um email. Se existente retorna um objeto do tipo Usuarios com os dados do mesmo.
        /// </summary>
        /// <param name="pEmail">String Email.</param>
        /// <returns>Objeto do tipo Usuarios.</returns>
        public static Usuarios GetUserEmail(string pEmail)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@email", pEmail);           

            sql.Append("SELECT * FROM Usuarios WHERE email = @email");

            cmm.CommandText = sql.ToString();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                user = new Usuarios
                {
                    idUsuario = Convert.ToInt32(row["idUsuario"]),
                    nome = (string)row["nome"],
                    email = (string)row["email"],
                    senha = (string)row["senha"],
                    verificacao = (string)row["verificacao"]
                };
            }

            dt.Dispose();

            Usuarios usuarioReturn = UsuariosUtil.ToFirstUpper(user);

            user = null;

            return usuarioReturn;

        }

        /// <summary>
        /// Metodo para buscar um usuario. Recebe como parametro um id de usuario. Se existente retorna um objeto do tipo Usuarios com os dados do mesmo.
        /// </summary>
        /// <param name="pId">String idUsuario.</param>
        /// <returns>Objeto do tipo Usuarios.</returns>
        public static Usuarios GetUserId(string pId)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@id", pId);

            sql.Append("SELECT * FROM Usuarios WHERE idUsuario = @id");

            cmm.CommandText = sql.ToString();

            DataTable dt = MySQL.MySQL.MySQL.getDataTable(cmm);

            foreach (DataRow row in dt.Rows)
            {
                user = new Usuarios
                {
                    idUsuario = Convert.ToInt32(row["idUsuario"]),
                    nome = (string)row["nome"],
                    email = (string)row["email"],
                    senha = (string)row["senha"],
                    verificacao = (string)row["verificacao"]
                };
            }

            dt.Dispose();

            Usuarios usuarioReturn = UsuariosUtil.ToFirstUpper(user);

            user = null;

            return usuarioReturn;
        }

        /// <summary>
        /// Metodo para inserir novo usuario com retorno do id do Usuario inserido. Recebe como parametro um objeto do tipo Usuarios.
        /// </summary>
        /// <param name="pUser">Objeto Usuarios.</param>
        /// <returns>Id do Usuario.</returns>
        public static int Create(Usuarios pUser)
        {
            MySqlCommand cmm = new MySqlCommand();

            var senhaCriptografada = Criptografar(pUser.senha);

            cmm.Parameters.AddWithValue("@nome", pUser.nome);
            cmm.Parameters.AddWithValue("@email", pUser.email);
            cmm.Parameters.AddWithValue("@senha", senhaCriptografada);
            cmm.Parameters.AddWithValue("@verificacao", "F");

            StringBuilder sql = new StringBuilder();
            sql.Append("CALL insertUsuario (@nome,@email,@senha,@verificacao) ");

            cmm.CommandText = sql.ToString();

            int idreturn = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            return idreturn;
        }

        /// <summary>
        /// Metodo para verificar a existencia de um email ja cadastrado. Recebe como parametro um email. Se existente retorna true ou caso nao exista false.
        /// </summary>
        /// <param name="pEmail">String Email.</param>
        /// <returns>Verdadeiro ou Falso.</returns>
        public static bool VerificaEmail(string pEmail)
        {
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@email", pEmail);

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT COUNT(*) FROM Usuarios WHERE email = @email");

            cmm.CommandText = sql.ToString();

            int cont = MySQL.MySQL.MySQL.ExecuteScalar(cmm);

            if (cont == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Metodo para verificar email e liberar o uso de usuario cadastrado. Recebe como parametro um id de usuario.
        /// </summary>
        /// <param name="pIdUser">String idUsuario.</param>
        public static void UpdateVerificacao(string pIdUser)
        {
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idUsuario", pIdUser);
            cmm.Parameters.AddWithValue("@verificacao", "V");

            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Usuarios SET verificacao = @verificacao ");
            sql.Append("WHERE idUsuario = @idUsuario");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        /// <summary>
        /// Metodo para alterar a senha de cadastro de usuario, recebe como parametro com objeto do tipo Usuarios.
        /// </summary>
        /// <param name="pUser">Objeto Usuarios.</param>
        public static void AlteraSenha(Usuarios pUser)
        {
            MySqlCommand cmm = new MySqlCommand();
            var senhaCriptografada = Criptografar(pUser.senha);

            cmm.Parameters.AddWithValue("@email", pUser.email);
            cmm.Parameters.AddWithValue("@senha", senhaCriptografada);

            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE Usuarios");
            sql.Append(" SET senha = @senha");
            sql.Append(" WHERE email = @email");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        /// <summary>
        /// Metodo para editar dados de um usuario cadastrado no sistema. Recebe como parametro um objeto do tipo Usuarios.
        /// </summary>
        /// <param name="pUser">Objeto Usuarios.</param>
        public static void EditarUsuario(Usuarios pUser)
        {
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idUsuario", pUser.idUsuario);
            cmm.Parameters.AddWithValue("@nome", pUser.nome);
            cmm.Parameters.AddWithValue("@email", pUser.email);

            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE Usuarios");
            sql.Append(" SET nome = @nome, email = @email");
            sql.Append(" WHERE idUsuario = @idUsuario");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        /// <summary>
        /// Metodo para excluir a conta de usuario do sistema. Recebe como parametro um objeto do tipo Usuarios.
        /// </summary>
        /// <param name="pUser">Objeto Usuarios.</param>
        public static void ExcluirConta(Usuarios pUser)
        {
            MySqlCommand cmm = new MySqlCommand();

            cmm.Parameters.AddWithValue("@idUsuario", pUser.idUsuario);

            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM Usuarios");
            sql.Append(" WHERE idUsuario = @idUsuario");

            cmm.CommandText = sql.ToString();

            MySQL.MySQL.MySQL.ExecuteQuery(cmm);
        }

        /// <summary>
        /// Metodo para criptografar senha de usuario. Recebe como parametro uma string. Retorna a senha criptografada em formato string.
        /// </summary>
        /// <param name="senha">String senha.</param>
        /// <returns>Senha criptografada.</returns>
        public static string Criptografar(string senha)
        {
            return Crypter.MD5.Crypt(senha);
        }

        /// <summary>
        /// Metodo para checar se a senha digitada pelo usuario confere com a senha criptografa salva. Recebe como parametro a senha digitada e o hash do banco. Retornar verdadeiro ou falso.
        /// </summary>
        /// <param name="senha">String senha.</param>
        /// <param name="hash">String hash.</param>
        /// <returns>Verdadeiro ou Falso.</returns>
        public static bool Checar(string senha, string hash)
        {
            return Crypter.CheckPassword(senha, hash);
        }
    }
}