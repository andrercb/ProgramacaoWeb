using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUD.Domain.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public string NomePerfil { get; set; }
        public string DescricaoPerfil { get; set; }
        public DateTime Dt_cadastro { get; set; }
        public DateTime Dt_atualizacao { get; set; }
        public bool Deletado { get; set; }
    }
}
