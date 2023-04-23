namespace Bijuus.Models;

    public class DetailsDto
    {
        public Personagem Prior { get; set; }
        public Personagem Current { get; set; }
        public Personagem Next { get; set; }
        public List<Vila> Vilas { get; set; }
    }
