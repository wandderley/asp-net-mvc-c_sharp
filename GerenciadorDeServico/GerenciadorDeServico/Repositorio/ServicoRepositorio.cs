using GerenciadorDeServico.Data;
using GerenciadorDeServico.Models;

namespace GerenciadorDeServico.Repositorio
{
    public class ServicoRepositorio : IServicoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ServicoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ServicoModel ListarPorId(int id)
        {
            return _bancoContext.Servicos.FirstOrDefault(x => x.Id == id);
        }

        public List<ServicoModel> BuscarTodos()
        {
            return _bancoContext.Servicos.ToList();
        }

        public ServicoModel Adicionar(ServicoModel servico)
        {
            _bancoContext.Servicos.Add(servico);
            _bancoContext.SaveChanges();
            return servico;
        }  

        public ServicoModel Atualizar(ServicoModel servico)
        {
            ServicoModel servicoDB = ListarPorId(servico.Id);

            if (servicoDB == null) throw new System.Exception("Houve um erro na atualização do serviço!");

            servicoDB.Local = servico.Local;
            servicoDB.Numero = servico.Numero;
            servicoDB.Data = servico.Data;
            servicoDB.Valor = servico.Valor;
            servicoDB.Descricao = servico.Descricao;

            _bancoContext.Servicos.Update(servicoDB);
            _bancoContext.SaveChanges();

            return servicoDB;
        }

        public bool Apagar(int id)
        {
            ServicoModel servicoDB = ListarPorId(id);

            if (servicoDB == null) throw new System.Exception("Houve erro na deleção do serviço!");

            _bancoContext.Servicos.Remove(servicoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
