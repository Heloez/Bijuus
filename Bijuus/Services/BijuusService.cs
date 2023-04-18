using System.Text.Json;
using Bijuus.Models

namespace Bijuus.Services;

public class BijuusService : IBijuuService.
{
    private readonly IHttpContextAccessor _session;
    private readonly string BijuusFile = @"Data\Bijuus.json";
    private readonly string caracteristicasFile = @"Data\caracteristicas.json";

    public BijuusService(IHttpContextAccessor session)
{
    _session = session;
    PopularSessao();
}

public List<caracteristicas> Getcaracteristicas()
{
    PopularSessao();
    var caracteristicas = JsonSerializer.Deserialize<List<caracteristicas>>(_session.HttpContext.Session.GetString("caracteristicas"));
    return caracteristicas;
}

public Bijuus GetBijuus(int Numero)
{
    var Bijuus = GetBijuus();
    return Bijuus.Where(p => p.Numero == Numero).FirstOrDefault();
}

public BijuusDto GetBijuusDto()
{
    var Bijuus = new bijuusDto()
    {
        caracteristicas = Getcaracteristicas(),
    };
    return Bijuus;
}

public DetailsDto GetDetailedbijuus(int Numero)
{
    var Bijuus = Getbijuus();
    var Bijuus = new DetailsDto()
    {
        Current = Bijuus.Where(p => p.Numero == Numero).FirstOrDefault(),
        Prior = Bijuus.OrderByDescending(p => p.Numero) .FirstOrDefault(p => p.Numero < Numero),
        Next = Bijuus.OrderBy(p => p.Numero) .FirstOrDefault(p => p.Numero > Numero),
    };
    Bijuus.caracteristicas = Getcaracteristicas();
    return Bijuus;
}

public caracteristicas Getcaracteristicas(string Nome)
{
    var caracteristicas = Getcaracteristicas();
    return caracteristicas.Where(t => t.Nome == Nome).FirstOrDefault();
}

private void PopularSessao()
{
     if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("caracteristicas")))
    {
        _session.HttpContext.Session.SetString("caracteristicas", LerArquivo(bijuusFile));
        _session.HttpContext.Session.SetString("caracteristicas", LerArquivo(caracteristicasFile));
    }
}

private string LerArquivo(string fileName)
    {
    using (StreamReader leitor = new StreamReader(fileName))
        {
        string dados = leitor.ReadToEnd();
        return dados;
      }
    }
}