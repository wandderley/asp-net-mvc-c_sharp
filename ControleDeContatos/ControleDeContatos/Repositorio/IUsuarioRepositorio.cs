using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> BuscarTodos();
        ContatoModel ListarPorId(int id);        
        ContatoModel Adicionar(UsuarioModel contato);
        ContatoModel Atualizar(UsuarioModel contato);
        bool Apagar(int id);
    }
}
