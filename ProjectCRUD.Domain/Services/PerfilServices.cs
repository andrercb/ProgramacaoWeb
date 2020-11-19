using ProjectCRUD.Domain.Interfaces.Repositorys;
using ProjectCRUD.Domain.Interfaces.Services;
using ProjectCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUD.Domain.Services
{


    public class PerfilServices : IPerfilServices
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilServices(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }


        public List<Perfil> ListPerfil()
        {
            try
            {
                return _perfilRepository.ListPerfil();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
