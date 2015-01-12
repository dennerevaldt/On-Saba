using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Entidade
{
    public class Associados : Pessoas
    {
        #region Atributos

        [Key]
        public int idAssociado { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Residencia é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100)]
        [DisplayName("Tipo de Residência")]
        public string tipoResidencia { get; set; }

        public List<Dependentes> dependentes { get; set; }

        #endregion
    }
}