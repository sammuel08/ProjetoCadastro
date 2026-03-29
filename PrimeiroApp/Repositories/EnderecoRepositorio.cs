using MySql.Data.MySqlClient;
using PrimeiroApp.Models;
using PrimeiroApp.Repositories.Contracts;
using System.Data;

namespace PrimeiroApp.Repositories
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly string _conexaoMySql;
        public EnderecoRepositorio(IConfiguration conf)
        {
            _conexaoMySql = conf.GetConnectionString("ConexaoMySql");
        }
        public void Atualizar(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Endereco endereco)
        {
            try
            {
                using (var conexao = new MySqlConnection(_conexaoMySql))
                {
                    conexao.Open();

                    MySqlCommand cmd = new MySqlCommand("insert into Endereco(CEP, Estado, Cidade, Bairro," +
                           " Logradouro, Complemento, Numero) " +
                                                    " values (@CEP, @Estado, @Cidade, @Bairro, @Endereco, @Complemento, @Numero )", conexao);
                    cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = endereco.CEP;
                    cmd.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = endereco.Estado;
                    cmd.Parameters.Add("@Cidade", MySqlDbType.VarChar).Value = endereco.Cidade;
                    cmd.Parameters.Add("@Bairro", MySqlDbType.VarChar).Value = endereco.Bairro;
                    cmd.Parameters.Add("@Endereco", MySqlDbType.VarChar).Value = endereco.Logradouro;
                    cmd.Parameters.Add("@Complemento", MySqlDbType.VarChar).Value = endereco.Complemento;
                    cmd.Parameters.Add("@Numero", MySqlDbType.VarChar).Value = endereco.Numero;

                    cmd.ExecuteNonQuery();

                    conexao.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro no banco em cadastrar cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação em cadastro cliente: " + ex.Message);
            }
        }

            

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Endereco ObterEndereco(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> ObterEnderecos()
        {
            List<Endereco> endList = new List<Endereco>();
            using (var conexao = new MySqlConnection(_conexaoMySql))
            { 
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ENDERECO", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    endList.Add(
                        new Endereco
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            CEP = Convert.ToString(dr["CEP"]),
                            Estado = Convert.ToString(dr["Estado"]),
                            Cidade = Convert.ToString(dr["Cidade"]),
                            Bairro = Convert.ToString(dr["Bairro"]),
                            Logradouro = Convert.ToString(dr["Logradouro"]),
                            Complemento = Convert.ToString(dr["Complemento"]),
                            Numero = Convert.ToString(dr["Numero"])
                        });
                }
                return endList;
            }
        }
    }
}
