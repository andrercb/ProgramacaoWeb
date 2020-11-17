using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCRUD.Domain.Models;

namespace ProjectCRUD.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        void Save(Usuario usuario);
        void Delete(int id);
        void Update(Usuario id);
        List<Usuario> ListUsuario();
        Usuario GetUsuario(int id);
        Usuario GetUsuarioCPF(string cpfUsuario);
    }
}
