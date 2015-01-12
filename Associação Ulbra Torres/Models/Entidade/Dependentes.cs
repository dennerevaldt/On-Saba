using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Entidade
{
    public class Dependentes : Pessoas
    {
        #region Atributos

        [Key]
        public int idDependente { get; set; }

        public Associados associado  { get; set; }

        [Required(ErrorMessage = "O campo Parentesco é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayName("Parentesco")]
        public string parentesco   { get; set; }

        [DisplayName("Escola")]
        public Escolas escola  { get; set; }

        #endregion
    }
}