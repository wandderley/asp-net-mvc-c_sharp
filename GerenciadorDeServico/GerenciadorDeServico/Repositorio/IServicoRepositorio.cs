using GerenciadorDeServico.Models;

namespace GerenciadorDeServico.Repositorio
{
    public interface IServicoRepositorio
    {
        ServicoModel ListarPorId(int id);
        List<ServicoModel> BuscarTodos();
        ServicoModel Adicionar(ServicoModel servico);
        ServicoModel Atualizar(ServicoModel servico);
        bool Apagar(int id);

    }
}
