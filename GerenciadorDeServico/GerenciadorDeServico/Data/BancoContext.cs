using GerenciadorDeServico.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeServico.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<ServicoModel> Servicos { get; set; }
    }
}