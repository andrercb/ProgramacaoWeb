using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCRUD.Domain.Models;

namespace ProjectCRUD.Domain.Interfaces.Repositorys
{
    public interface IEmpresaRepository
    {
        List<Empresa> ListEmpresa();

    }
}
