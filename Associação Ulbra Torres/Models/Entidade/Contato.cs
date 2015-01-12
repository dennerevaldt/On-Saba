using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Associação_Ulbra_Torres.Models.Entidade
{
    public class Contato
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        public string fName { get; set; }

        [Required(ErrorMessage = "O campo Segundo Nome é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        public string lName { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Preencha com um email válido")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^\d+$", ErrorMessage = "O campo aceita somente números inteiros.")]
        public string phone { get; set; }

        [Required(ErrorMessage = "O campo Mensagem é obrigatório.", AllowEmptyStrings = false)]
        public string message { get; set; }
    }
}