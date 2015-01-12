using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Associação_Ulbra_Torres.Models.Entidade
{
    public abstract class Pessoas
    {
        #region Atributos

        [Key]
        public int idPessoa { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo Nacionalidade é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        [DisplayName("Nacionalidade")]
        public string nacionalidade { get; set; }

        [Required(ErrorMessage = "O campo Naturalidade é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        [DisplayName("Naturalidade")]
        public string naturalidade { get; set; }

        [Required(ErrorMessage = "O campo Estado Naturalidade é obrigatório.", AllowEmptyStrings = false)]
        [DisplayName("Estado Naturalidade")]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        public string estadoNaturalidade { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.", AllowEmptyStrings = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Nascimento")]
        public DateTime dataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Estado Civil é obrigatório.", AllowEmptyStrings = false)]
        [DisplayName("Estado Civil")]
        public string estadoCivil { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}|^\d{11}$", ErrorMessage = "O CPF deverá estar no formato 000.000.000-00 ou 00000000000")]
        [DisplayName("CPF")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "O RG deverá estar no formato 0000000000")]
        [DisplayName("RG")]
        public string rg { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "O campo aceita somente números inteiros.")]
        [StringLength(60)]
        [DisplayName("Título de Eleitor")]
        public string tituloDeEleitor { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "O campo aceita somente números inteiros.")]
        [StringLength(60)]
        [DisplayName("Zona")]
        public string zona { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "O campo aceita somente números inteiros.")]
        [StringLength(60)]
        [DisplayName("Seção")]
        public string secao { get; set; }

        [Required(ErrorMessage = "O campo Endereco é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(120)]
        [DisplayName("Endereço")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "O campo Numero é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^\d+$", ErrorMessage = "O campo aceita somente números inteiros.")]
        [DisplayName("Número")]
        public string numero { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        [DisplayName("Bairro")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        [DisplayName("Cidade")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z\sà-ùÀ-Ù ""]+$", ErrorMessage = "O campo aceita somenta Letras.")]
        [DisplayName("Estado")]
        public string estado { get; set; }

        [Required(ErrorMessage = "O CEP deve ser informado.")]
        [RegularExpression(@"^\d{8}$|^\d{5}-\d{3}$", ErrorMessage = "O código postal deverá estar no formato 00000000 ou 00000-000")]
        [DisplayName("CEP")]
        public string cep { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório.", AllowEmptyStrings = false)]
        [DisplayName("Sexo")]
        public char sexo { get; set; }

        [StringLength(70)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Preencha com um email válido")]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Observações")]
        public string  observacoes { get; set; }

        [DisplayName("Telefones")]
        public List<Telefones> telefones { get; set; }

        [DisplayName("Religião")]
        public Religioes religiao { get; set; }

        #endregion
    }   
}