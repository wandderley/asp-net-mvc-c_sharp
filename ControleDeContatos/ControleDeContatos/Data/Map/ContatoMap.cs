using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeContatos.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.HasKey(x => x.Id); //Id é a chave primaria
            builder.HasOne(x => x.Usuario); // Passa o usuário
            //builder.Property(x => x.Nome).HasMaxLength(100); maximo de caracteres
        }
    }
}
