using ProjectCRUD.Domain.Models;
using ProjectCRUD.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUD.Infrastructure.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario GetUsuario(int id)
        {
            try
            {
                ProgramacaoWebEntities _db = new ProgramacaoWebEntities();
                Usuario usuario = new Usuario();


                var query = "SELECT * FROM TB_USUARIO WHERE usr_id =" + id;

                using (SqlConnection connection = new SqlConnection(_db.Database.Connection.ConnectionString.ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = connection;
                        connection.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                usuario = new Usuario
                                {
                                    id = Convert.ToInt32(sdr["usr_id"]),
                                    Nome = Convert.ToString(sdr["usr_nome"]),
                                    Sexo = Convert.ToString(sdr["usr_sexo"]),
                                    Senha = Convert.ToString(sdr["usr_senha"]),
                                    Cpf = Convert.ToString(sdr["usr_cpf"]),
                                    Dt_nascimento = Convert.ToDateTime(sdr["usr_dt_nascimento"]),
                                    Telefone = Convert.ToString(sdr["usr_telefone"]),
                                    Email = Convert.ToString(sdr["usr_email"]),
                                    Logradouro = Convert.ToString(sdr["usr_logradouro"]),
                                    ComplementoLogradouro = Convert.ToString(sdr["usr_complemento_logradouro"]),
                                    CodigoBairro = Convert.ToInt32(sdr["brr_codigo"]),
                                    CodigoMunicipio = Convert.ToInt32(sdr["mnp_codigo_ibge"]),
                                    Cep = Convert.ToString(sdr["usr_cep"]),
                                    CodigoUf = Convert.ToInt32(sdr["uf_codigo"]),
                                    CodigoEmpresa = Convert.ToInt32(sdr["emp_id"]),
                                    CodigoPerfil = Convert.ToInt32(sdr["pfl_id"]),
                                    Dt_cadastro = Convert.ToDateTime(sdr["usr_dt_cadastro"]),
                                    Dt_atualizacao = Convert.ToDateTime(sdr["usr_dt_atualizacao"]),
                                    Deletado = Convert.ToBoolean(sdr["usr_deletado"]),
                                };
                            }
                        }
                        connection.Close();
                    }
                }
                return usuario;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<Usuario> ListUsuario()
        {
            try
            {
                ProgramacaoWebEntities _db = new ProgramacaoWebEntities();
                List<Usuario> listUsuario = new List<Usuario>();

                var query = "SELECT * FROM TB_USUARIO WHERE [usr_deletado] = 0";

                using (SqlConnection connection = new SqlConnection(_db.Database.Connection.ConnectionString.ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = connection;
                        connection.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                Usuario usuario = new Usuario()
                                {
                                    id = Convert.ToInt32(sdr["usr_id"]),
                                    Nome = Convert.ToString(sdr["usr_nome"]),
                                    Sexo = Convert.ToString(sdr["usr_sexo"]),
                                    Cpf = Convert.ToString(sdr["usr_cpf"]),
                                    Dt_nascimento = Convert.ToDateTime(sdr["usr_dt_nascimento"]),
                                    Telefone = Convert.ToString(sdr["usr_telefone"]),
                                    Email = Convert.ToString(sdr["usr_email"]),
                                    Logradouro = Convert.ToString(sdr["usr_logradouro"]),
                                    ComplementoLogradouro = Convert.ToString(sdr["usr_complemento_logradouro"]),
                                    CodigoBairro = Convert.ToInt32(sdr["brr_codigo"]),
                                    CodigoMunicipio = Convert.ToInt32(sdr["mnp_codigo_ibge"]),
                                    Cep = Convert.ToString(sdr["usr_cep"]),
                                    CodigoUf = Convert.ToInt32(sdr["uf_codigo"]),
                                    CodigoEmpresa = Convert.ToInt32(sdr["emp_id"]),
                                    Dt_cadastro = Convert.ToDateTime(sdr["usr_dt_cadastro"]),
                                    Dt_atualizacao = Convert.ToDateTime(sdr["usr_dt_atualizacao"]),
                                    Deletado = Convert.ToBoolean(sdr["usr_deletado"]),
                                };

                                listUsuario.Add(usuario);
                            }
                        }
                        connection.Close();
                    }
                }
                return listUsuario;
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
                ProgramacaoWebEntities _db = new ProgramacaoWebEntities();

                var query = "INSERT INTO[ProgramacaoWeb].[dbo].[TB_USUARIO]" +
                                "([usr_nome]" + ",[usr_cpf]" + ",[usr_sexo]" + ",[usr_dt_nascimento]" + ",[usr_telefone]" + ",[usr_email]" + ",[usr_senha]" + ",[usr_logradouro]" + ",[usr_complemento_logradouro]" +
                                ",[brr_codigo]" + ",[mnp_codigo_ibge]" + ",[usr_cep]" + ",[uf_codigo]" + ",[emp_id]" + ",[pfl_id]" + ",[usr_dt_cadastro]" + ",[usr_dt_atualizacao]" + ",[usr_deletado])" +
                                "VALUES(@Nome,@Cpf,@Sexo,@Dt_nascimento,@Telefone,@Email,@Senha,@Logradouro,@ComplementoLogradouro,@CodigoBairro,@CodigoMunicipio,@Cep,@CodigoUf,@CodigoEmpresa,@CodigoPerfil,GETDATE(),GETDATE(),0)";


                using (SqlConnection connection = new SqlConnection(_db.Database.Connection.ConnectionString.ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Dt_nascimento", usuario.Dt_nascimento);
                        cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                        cmd.Parameters.AddWithValue("@Logradouro", usuario.Logradouro);
                        cmd.Parameters.AddWithValue("@ComplementoLogradouro", usuario.ComplementoLogradouro);
                        cmd.Parameters.AddWithValue("@CodigoBairro", usuario.CodigoBairro);
                        cmd.Parameters.AddWithValue("@CodigoMunicipio", usuario.CodigoMunicipio);
                        cmd.Parameters.AddWithValue("@Cep", usuario.Cep);
                        cmd.Parameters.AddWithValue("@CodigoUf", usuario.CodigoUf);
                        cmd.Parameters.AddWithValue("@CodigoEmpresa", usuario.CodigoEmpresa);
                        cmd.Parameters.AddWithValue("@CodigoPerfil", usuario.CodigoPerfil);

                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Update(Usuario usuario)
        {
            try
            {
                ProgramacaoWebEntities _db = new ProgramacaoWebEntities();

                var query = "UPDATE [ProgramacaoWeb].[dbo].[TB_USUARIO] " +
                            "SET[usr_nome] = @Nome" +
                            ",[usr_cpf] = @Cpf" +
                            ",[usr_sexo] = @Sexo" +
                            ",[usr_dt_nascimento] = @Dt_nascimento" +
                            ",[usr_telefone] = @Telefone" +
                            ",[usr_email] = @Email" +
                            ",[usr_logradouro] = @Logradouro" +
                            ",[usr_complemento_logradouro] = @ComplementoLogradouro" +
                            ",[brr_codigo] = @CodigoBairro" +
                            ",[mnp_codigo_ibge] = @CodigoMunicipio" +
                            ",[usr_cep] = @Cep" +
                            ",[uf_codigo] = @CodigoUf" +
                            ",[emp_id] = @CodigoEmpresa" +
                            ",[pfl_id] = @CodigoPerfil" +
                            ",[usr_dt_atualizacao] = GETDATE()" +
                            "WHERE" +
                            " [usr_id] = " + usuario.id;


                using (SqlConnection connection = new SqlConnection(_db.Database.Connection.ConnectionString.ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Dt_nascimento", usuario.Dt_nascimento);
                        cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Logradouro", usuario.Logradouro);
                        cmd.Parameters.AddWithValue("@ComplementoLogradouro", usuario.ComplementoLogradouro);
                        cmd.Parameters.AddWithValue("@CodigoBairro", usuario.CodigoBairro);
                        cmd.Parameters.AddWithValue("@CodigoMunicipio", usuario.CodigoMunicipio);
                        cmd.Parameters.AddWithValue("@Cep", usuario.Cep);
                        cmd.Parameters.AddWithValue("@CodigoUf", usuario.CodigoUf);
                        cmd.Parameters.AddWithValue("@CodigoEmpresa", usuario.CodigoEmpresa);
                        cmd.Parameters.AddWithValue("@CodigoPerfil", usuario.CodigoPerfil);

                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Delete(int id)
        {
            try
            {
                ProgramacaoWebEntities _db = new ProgramacaoWebEntities();

                var query = "UPDATE [ProgramacaoWeb].[dbo].[TB_USUARIO]" +
                            "SET[usr_deletado] = @Deletado" +
                            " WHERE" +
                            " [usr_id] = " + id;

                using (SqlConnection connection = new SqlConnection(_db.Database.Connection.ConnectionString.ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Deletado", 1);

                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public Usuario GetUsuarioCPF(string cpf)
        {
            try
            {
                ProgramacaoWebEntities _db = new ProgramacaoWebEntities();
                Usuario usuario = new Usuario();


                var query = "SELECT * FROM TB_USUARIO WHERE usr_cpf =" + "'" + cpf + "'";

                using (SqlConnection connection = new SqlConnection(_db.Database.Connection.ConnectionString.ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = connection;
                        connection.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                usuario = new Usuario
                                {
                                    id = Convert.ToInt32(sdr["usr_id"]),
                                    Nome = Convert.ToString(sdr["usr_nome"]),
                                    Sexo = Convert.ToString(sdr["usr_sexo"]),
                                    Senha = Convert.ToString(sdr["usr_senha"]),
                                    Cpf = Convert.ToString(sdr["usr_cpf"]),
                                    Dt_nascimento = Convert.ToDateTime(sdr["usr_dt_nascimento"]),
                                    Telefone = Convert.ToString(sdr["usr_telefone"]),
                                    Email = Convert.ToString(sdr["usr_email"]),
                                    Logradouro = Convert.ToString(sdr["usr_logradouro"]),
                                    ComplementoLogradouro = Convert.ToString(sdr["usr_complemento_logradouro"]),
                                    CodigoBairro = Convert.ToInt32(sdr["brr_codigo"]),
                                    CodigoMunicipio = Convert.ToInt32(sdr["mnp_codigo_ibge"]),
                                    Cep = Convert.ToString(sdr["usr_cep"]),
                                    CodigoUf = Convert.ToInt32(sdr["uf_codigo"]),
                                    CodigoEmpresa = Convert.ToInt32(sdr["emp_id"]),
                                    CodigoPerfil = Convert.ToInt32(sdr["pfl_id"]),
                                    Dt_cadastro = Convert.ToDateTime(sdr["usr_dt_cadastro"]),
                                    Dt_atualizacao = Convert.ToDateTime(sdr["usr_dt_atualizacao"]),
                                    Deletado = Convert.ToBoolean(sdr["usr_deletado"]),
                                };
                            }
                        }
                        connection.Close();
                    }
                }
                return usuario;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
