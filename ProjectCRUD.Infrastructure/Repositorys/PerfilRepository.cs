using ProjectCRUD.Domain.Interfaces.Repositorys;
using ProjectCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectCRUD.Infrastructure.Repositorys
{
    public class PerfilRepository : IPerfilRepository
    {
        public List<Perfil> ListPerfil()
        {
            try
            {
                ProgramacaoWebEntities _db = new ProgramacaoWebEntities();
                List<Perfil> listPerfil = new List<Perfil>();

                var query = "SELECT * FROM TB_PERFIL WHERE [pfl_deletado] = 0";

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
                                Perfil Perfil = new Perfil()
                                {
                                    Id = Convert.ToInt32(sdr["pfl_id"]),
                                    NomePerfil = Convert.ToString(sdr["pfl_nome"]),
                                    DescricaoPerfil = Convert.ToString(sdr["pfl_descricao"]),
                                    Dt_cadastro = Convert.ToDateTime(sdr["pfl_dt_cadastro"]),
                                    Dt_atualizacao = Convert.ToDateTime(sdr["pfl_dt_atualizacao"]),
                                    Deletado = Convert.ToBoolean(sdr["pfl_deletado"]),
                                };

                                listPerfil.Add(Perfil);
                            }
                        }
                        connection.Close();
                    }
                }
                return listPerfil;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
