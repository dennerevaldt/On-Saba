using Associação_Ulbra_Torres.Models.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Utilitarios
{
    public class UsuariosUtil
    {
        private static Usuarios newUser;
        public static Usuarios ToLowerUsuario(Usuarios item)
        {
            newUser = new Usuarios();

            newUser.idUsuario = item.idUsuario;
            newUser.nome = item.nome.ToLower();
            newUser.email = item.email.ToLower();
            newUser.senha = item.senha;
            newUser.verificacao = item.verificacao.ToUpper();

            return newUser;
        }

        public static Usuarios ToFirstUpper(Usuarios item)
        {
            if (item != null)
            {
                newUser = new Usuarios();
                System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

                try
                {
                    string nome = item.nome.Substring(0, item.nome.IndexOf(" "));
                    newUser.nome = cultureInfo.TextInfo.ToTitleCase(nome);
                }
                catch (Exception)
                {
                    newUser.nome = cultureInfo.TextInfo.ToTitleCase(item.nome);
                }

                newUser.idUsuario = item.idUsuario;
                newUser.email = item.email.ToLower();
                newUser.senha = item.senha;
                newUser.verificacao = item.verificacao.ToUpper();

                return newUser;
            }
            else
            {
                newUser = null;
                return newUser;
            }
            

            
        }
    }
}