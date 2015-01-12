using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Entidade
{
    public class Telefones
    {
        #region Atributos

        [Key]
        public int idTelefone  { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(60)]
        [DisplayName("Tipo")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "O campo Numero é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(60)]
        [RegularExpression(@"^[(]{1}\d{3}[)]{1}\d{4}[-]{1}\d{4}$", ErrorMessage = "Forneça o número do telefone no formato (000) 0000-0000")]
        [DisplayName("Numero")]
        public string numero { get; set; }

        #endregion
    }
}