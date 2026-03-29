using PrimeiroApp.Models;
namespace PrimeiroApp.Repositories.Contracts
{
    public interface IEnderecoRepositorio
    {
        void Cadastrar(Endereco endereco);

        void Atualizar(Endereco endereco);

        void Excluir(int id);

        Endereco ObterEndereco(int id);

        IEnumerable<Endereco> ObterEnderecos();
        
    }
}
