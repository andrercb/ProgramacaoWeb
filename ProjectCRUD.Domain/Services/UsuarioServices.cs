using Caelum.Stella.CSharp.Validation;
using ProjectCRUD.Domain.Interfaces.Services;
using ProjectCRUD.Domain.Models;
using ProjectCRUD.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPFValidator = Caelum.Stella.CSharp.Validation.CPFValidator;

namespace ProjectCRUD.Domain.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> ListUsuario()
        {
            try
            {
                var listUsuario = _usuarioRepository.ListUsuario();

                listUsuario.ForEach(f => f.Cpf = Convert.ToUInt64(f.Cpf).ToString(@"000\.000\.000\-00"));
                listUsuario.ForEach(f => f.Telefone = Convert.ToUInt64(f.Telefone).ToString(@"(00)00000-0000"));

                return (listUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario GetUsuario(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetUsuario(id);

                usuario.Cpf = Convert.ToUInt64(usuario.Cpf).ToString(@"000\.000\.000\-00");
                usuario.Telefone = Convert.ToUInt64(usuario.Telefone).ToString(@"(00)00000-0000");

                return usuario;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public void Save(Usuario usuario)
        {
            try
            {

                usuario.Cpf = !string.IsNullOrEmpty(usuario.Cpf) ? usuario.Cpf.Replace(".", "").Replace("-", "") : usuario.Cpf;
                usuario.Cep = !string.IsNullOrEmpty(usuario.Cep) ? usuario.Cep.Replace(".", "").Replace("-", "") : usuario.Cep;
                usuario.Telefone = !string.IsNullOrEmpty(usuario.Telefone) ? usuario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "") : usuario.Telefone;
                usuario.Deletado = false;

                _usuarioRepository.Save(usuario);

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        void IUsuarioServices.Update(Usuario usuario)
        {
            try
            {
                usuario.Cpf = !string.IsNullOrEmpty(usuario.Cpf) ? usuario.Cpf.Replace(".", "").Replace("-", "") : usuario.Cpf;
                usuario.Cep = !string.IsNullOrEmpty(usuario.Cep) ? usuario.Cep.Replace(".", "").Replace("-", "") : usuario.Cep;
                usuario.Telefone = !string.IsNullOrEmpty(usuario.Telefone) ? usuario.Telefone.Replace("(", "").Replace(")", "").Replace("-", "") : usuario.Telefone;

                _usuarioRepository.Update(usuario);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        void IUsuarioServices.Delete(int id)
        {
            try
            {
                _usuarioRepository.Delete(id);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public Usuario GetUsuarioCPF(string cpfUsuario)
        {
            try
            {
                cpfUsuario = !string.IsNullOrEmpty(cpfUsuario) ? cpfUsuario.Replace(".", "").Replace("-", "") : cpfUsuario;

                var usuario = _usuarioRepository.GetUsuarioCPF(cpfUsuario);

                return usuario;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
