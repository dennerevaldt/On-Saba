using Associação_Ulbra_Torres.Models.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Utilitarios
{
    public class EscolasUtil
    {
        public static Escolas newEscola;
        public static List<Escolas> newList;

        public static Escolas ToLowerEscola(Escolas item)
        {
            newEscola = new Escolas();

            newEscola.idEscola = item.idEscola;
            newEscola.nomeEscola = item.nomeEscola.ToLower();

            return newEscola;
        }

        public static Escolas ToUpperEscola(Escolas item)
        {
            newEscola = new Escolas();

            newEscola.idEscola = item.idEscola;
            newEscola.nomeEscola = item.nomeEscola.ToUpper();

            return newEscola;
        }

        public static Escolas ToFirstUpper(Escolas item)
        {
            newEscola = new Escolas();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            newEscola.idEscola = item.idEscola;
            newEscola.nomeEscola = cultureInfo.TextInfo.ToTitleCase(item.nomeEscola);

            return newEscola;
        }

        public static List<Escolas> ToFirstUpper(List<Escolas> pLista)
        {
            newList = new List<Escolas>();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            foreach (var item in pLista)
            {
                newList.Add
                (
                    new Escolas
                    {
                        idEscola = item.idEscola,
                        nomeEscola = cultureInfo.TextInfo.ToTitleCase(item.nomeEscola)
                    }
                );
            }

            return newList;
        }

    }
}