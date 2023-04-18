using Bijuus.Models;
namespace Bijuus.Services;
    
    public interface IbijuusService
    {
        List<caracteristicas> Getbijuus();
        Bijuus Getbijuus(int Numero);
        bijuusDto GetBijuusDto();
        DetailsDto GetDetailedBijuus(int Numero)
    }
