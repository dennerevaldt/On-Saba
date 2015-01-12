using Associação_Ulbra_Torres.Models.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Utilitarios
{
    public class ContatoUtil
    {
        public static Contato ToFirstUpper(Contato pFormContato)
        {
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            Contato newFormContato = new Contato();

            if (pFormContato != null)
            {
                newFormContato.fName = cultureInfo.TextInfo.ToTitleCase(pFormContato.fName);
                newFormContato.lName = cultureInfo.TextInfo.ToTitleCase(pFormContato.lName);
                newFormContato.email = pFormContato.email.ToLower();
                newFormContato.phone = pFormContato.phone;
                newFormContato.message = pFormContato.message.ToLower();

            }

            return newFormContato;

        }
    }
}