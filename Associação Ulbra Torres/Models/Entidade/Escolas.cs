using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Entidade
{
    public class Escolas
    {
        [Key]
        public int idEscola { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayName("Nome")]
        public string nomeEscola { get; set; }
    }
}