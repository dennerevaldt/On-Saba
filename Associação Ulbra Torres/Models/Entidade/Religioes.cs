using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Entidade
{
    public class Religioes
    {
        #region Atributos

        [Key]
        public int idReligiao { get; set; }

        [StringLength(60)]
        [DisplayName("Religiao")]
        public string nome { get; set; }

        #endregion
    }
}