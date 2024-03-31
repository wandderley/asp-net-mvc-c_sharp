using ControleDeContatos.Models;

namespace ControleDeContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario); // cria uma sessão
        void RemoverSessaoDoUsuario(); // remove uma sessão
        UsuarioModel BuscarSessaoDoUsuario(); // busca uma sessão
    }
}
