using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUD.Domain.Models
{
    public class Empresa
    {

        [Key]
        public int Id { get; set; }
        public string Nomefantasia { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public DateTime Dt_cadastro { get; set; }
        public DateTime Dt_atualizacao { get; set; }
        public bool Deletado { get; set; }


    }
}
