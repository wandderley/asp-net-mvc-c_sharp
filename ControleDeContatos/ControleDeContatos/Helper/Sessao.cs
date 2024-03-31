using ControleDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ControleDeContatos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext; // Permite Criar Sessões do Usuario

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado"); // busca a string da sessao

            if (string.IsNullOrEmpty(sessaoUsuario)) return null; // se a sessão nao estiver vazia, retornará nulo
            
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario); // Deserializa o objeto, transforma a string em UsuarioModel
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            // transforma tudo em JSON e salva o contato no formato string
            string valor = JsonConvert.SerializeObject(usuario); // serializa um objeto        
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor); // seta uma string para a sessão (key,value)
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado"); // passa o chave da sessão que deseja remover
        }
    }
}
