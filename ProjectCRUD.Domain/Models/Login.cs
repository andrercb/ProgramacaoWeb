using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Http;
using System.Web.UI;


namespace ProjectCRUD.Domain.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o CPF do usuário", AllowEmptyStrings = false)]
        [MinLength(14, ErrorMessage = "Cpf inválido.")]
        public string CpfUsuario { get; set; }


        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string SenhaUsuario { get; set; }

        public static bool Logado
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["Logado"] == null)
                {
                    System.Web.HttpContext.Current.Session["Logado"] = false;
                }
                return (bool)System.Web.HttpContext.Current.Session["Logado"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["Logado"] = value;
            }
        }

    }
}