using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Entidade
{
    public class Usuarios
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.", AllowEmptyStrings = false)]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Preencha com um email válido")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.", AllowEmptyStrings = false)]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string senha { get; set; }

        public string verificacao { get; set; }
    }
}