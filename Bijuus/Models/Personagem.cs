namespace Bijuus.Models;

public class Personagem
{
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Vila { get; set; }
        public string Imagem { get; set; }

        public Personagem()
        {
            Vila = new List<string>();
        }
}