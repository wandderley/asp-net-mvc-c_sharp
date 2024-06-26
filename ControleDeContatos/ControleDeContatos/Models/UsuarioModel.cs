﻿using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
            Contatos = new List<ContatoModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set;}

        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Selecione o perfil do usuário")]
        public PerfilEnum? Perfil { get; set;}

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set;}
        public DateTime DataCadastro { get; set;}
        public DateTime? DataAtualização { get; set;}
        public virtual List<ContatoModel> Contatos { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8); // passou para nova senha a informação do guid apenas os primeiros 8 caracteres
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
