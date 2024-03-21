using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeServico.Models
{
    public class ServicoModel
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do local")]
        public string Local { get; set; }

        [Required(ErrorMessage = "Digite o número do local")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Selecione uma data")]
        public DateTime? Data {  get; set; }

        [Required(ErrorMessage = "Digite o Valor do serviço")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "Digite uma descrição do serviço")]
        public string Descricao { get; set;}
        
    }
}
