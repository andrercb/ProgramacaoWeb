using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCRUD.Domain.Models;

namespace ProjectCRUD.Domain.Interfaces.Services
{
    public interface IEmpresaServices
    {
        List<Empresa> ListEmpresa();
    }
}
