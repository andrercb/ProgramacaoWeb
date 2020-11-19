using ProjectCRUD.Domain.Interfaces.Repositorys;
using ProjectCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectCRUD.Infrastructure.Repositorys
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public List<Empresa> ListEmpresa()
        {
            try
            {
                ProgramacaoWebEntities _db = new ProgramacaoWebEntities();
                List<Empresa> listEmpresa = new List<Empresa>();

                var query = "SELECT * FROM TB_EMPRESA WHERE [emp_deletado] = 0";

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
                                Empresa Empresa = new Empresa()
                                {
                                    Id = Convert.ToInt32(sdr["emp_id"]),
                                    Nomefantasia = Convert.ToString(sdr["emp_nm_fantasia"]),
                                    Logradouro = Convert.ToString(sdr["emp_logradouro"]),
                                    Complemento = Convert.ToString(sdr["emp_complemento"]),
                                    Bairro = Convert.ToString(sdr["emp_bairro"]),
                                    Municipio = Convert.ToString(sdr["emp_municipio"]),
                                    Uf = Convert.ToString(sdr["emp_uf"]),
                                    Cep = Convert.ToString(sdr["emp_cep"]),
                                    Telefone = Convert.ToString(sdr["emp_telefone"]),
                                    Dt_cadastro = Convert.ToDateTime(sdr["emp_dt_cadastro"]),
                                    Dt_atualizacao = Convert.ToDateTime(sdr["emp_dt_atualizacao"]),
                                    Deletado = Convert.ToBoolean(sdr["emp_deletado"]),
                                };

                                listEmpresa.Add(Empresa);
                            }
                        }
                        connection.Close();
                    }
                }
                return listEmpresa;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
