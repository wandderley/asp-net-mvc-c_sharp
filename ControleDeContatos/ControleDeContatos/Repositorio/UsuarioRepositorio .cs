using ControleDeContatos.Data;
using ControleDeContatos.Helper;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        private readonly ISessao _sessao;
        public UsuarioRepositorio(BancoContext bancoContext, ISessao sessao)
        {
            this._context = bancoContext;
            _sessao = sessao;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }
        public UsuarioModel BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {          
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash(); // transforma a senha para hash
            // gravar no banco de dados
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuário");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualização = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }
        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuariodb = BuscarPorId(alterarSenhaModel.Id);

            if (usuariodb == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (!usuariodb.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuariodb.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

            usuariodb.SetNovaSenha(alterarSenhaModel.NovaSenha);

            usuariodb.DataAtualização = DateTime.Now;

            _context.Usuarios.Update(usuariodb);
            _context.SaveChanges(); 

            return usuariodb;       
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = BuscarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro ao deletar o usuário");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges(true);
            return true;            
        }

        
    }
}
