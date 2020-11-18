using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Caelum.Stella.CSharp.Validation;

namespace ProjectCRUD.Domain.Models
{
    public partial class Usuario
    {

        public Usuario() { }

        public int id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [MinLength(14, ErrorMessage = "Cpf inválido.")]
        [CPFValid]
        public string Cpf { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dt_nascimento { get; set; }

        [Required]
        [MinLength(13, ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 4)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Display(Name = "Compl. Logradouro")]
        [Required]
        public string ComplementoLogradouro { get; set; }

        [Display(Name = "Bairro")]
        [Required]
        public int CodigoBairro { get; set; }

        [Display(Name = "Município")]
        [Required]
        public int CodigoMunicipio { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Cep inválido.")]
        public string Cep { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public int CodigoUf { get; set; }

        [Display(Name = "Empresa")]
        [Required]
        public int CodigoEmpresa { get; set; }

        [Display(Name = "Perfil")]
        [Required]
        public int CodigoPerfil { get; set; }

        [Display(Name = "Data do Cadastro")]
        public DateTime Dt_cadastro { get; set; }

        [Display(Name = "Data da Atualização")]
        public DateTime Dt_atualizacao { get; set; }

        [Display(Name = "Deletado")]
        public bool Deletado { get; set; }


    }

    public class CPFValid : ValidationAttribute
    {
        public string CPF
        {
            get { return CPF; }
            set
            {
                CPF = value;
            }
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                new CPFValidator().AssertValid(value.ToString());

                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Cpf inválido.");
            }
        }
    }

}