using System.Security.Cryptography;
using System.Text;

namespace ControleDeContatos.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor) // Define um método de extensão para a classe string
        {
            // Cria uma instância do algoritmo de hash SHA1
            var hash = SHA1.Create();

            // Cria um codificador ASCII para converter a string em bytes
            var encoding = new ASCIIEncoding();

            // Converte a string de entrada em um array de bytes
            var array = encoding.GetBytes(valor);

            // Calcula o hash SHA1 dos bytes da string
            array = hash.ComputeHash(array);

            // Cria um StringBuilder para armazenar o hash em formato hexadecimal
            var strHexa = new StringBuilder();

            // Itera sobre cada byte no array de hash
            foreach (var item in array)
            {
                // Converte o byte em uma representação hexadecimal de dois caracteres
                // e adiciona ao StringBuilder
                strHexa.Append(item.ToString("x2"));
            }

            // Retorna a representação em string do hash hexadecimal
            return strHexa.ToString();
        }

    }
}
