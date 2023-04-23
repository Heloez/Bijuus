using Bijuus.Models;
namespace Bijuus.Services;
    
    public interface IBijuService
    {
        List<Personagem> GetPersonagens();
        List<Vila> GetVilas();
        Personagem GetPersonagem(int Numero);
        BijuusDto GetBijuusDto();
        DetailsDto GetDetailedPersonagem(int Numero);
        Vila GetVila(string Nome);
    }
