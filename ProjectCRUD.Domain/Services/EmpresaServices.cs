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
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaServices(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public List<Empresa> ListEmpresa()
        {
            try
            {
                return _empresaRepository.ListEmpresa();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
