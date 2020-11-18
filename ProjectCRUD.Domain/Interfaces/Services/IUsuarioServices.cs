using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCRUD.Domain.Models;

namespace ProjectCRUD.Domain.Interfaces.Services
{
    public interface IUsuarioServices
    {
        List<Usuario> ListUsuario();
        Usuario GetUsuario(int id);
        void Save(Usuario usuario);
        void Delete(int id);
        void Update(Usuario id);
        Usuario GetUsuarioCPF(string cpfUsuario);
    }
}
