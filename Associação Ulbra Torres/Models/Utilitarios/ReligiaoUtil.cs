using Associação_Ulbra_Torres.Models.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Utilitarios
{
    public class ReligiaoUtil
    {
        public static Religioes ToFirstUpper(Religioes pReligiao)
        {
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            Religioes newReligiao = new Religioes();

            if (pReligiao != null)
            {
                newReligiao.nome = (pReligiao.nome == null) ? null : cultureInfo.TextInfo.ToTitleCase(pReligiao.nome);
            }

            return newReligiao;

        }
    }
}