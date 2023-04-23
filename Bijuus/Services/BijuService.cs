using System.Text.Json;
using Bijuus.Models;

namespace Bijuus.Services;

public class BijuService : IBijuService
{
    private readonly IHttpContextAccessor _session;
    private readonly string personagemFile = @"Data\personagens.json";
    private readonly string vilasFile = @"Data\vilas.json";

    public BijuService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }
    
    public List<Personagem> GetPersonagens()
    {
        PopularSessao();
        var personagens = JsonSerializer.Deserialize<List<Personagem>>(_session.HttpContext.Session.GetString("Personagens"));
        return personagens;
    }

    public List<Vila> GetVilas()
    {
        PopularSessao();
        var vilas = JsonSerializer.Deserialize<List<Vila>>(_session.HttpContext.Session.GetString("Vilas"));
        return vilas;
    }

    public Personagem GetPersonagem(int Numero)
    {
        var personagens = GetPersonagens();
        return personagens.Where(p => p.Numero == Numero).FirstOrDefault();
    }

    public BijuusDto GetBijuusDto()
    {
        var Biju = new BijuusDto()
        {
            Personagens = GetPersonagens(),
            Vilas = GetVilas()
        };
        return Biju;
    }

    public DetailsDto GetDetailedPersonagem(int Numero)
    {
        var personagens = GetPersonagens();
        var biju = new DetailsDto()
        {
            Current = personagens.Where(p => p.Numero == Numero).FirstOrDefault(),
            Prior = personagens.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < Numero),
            Next = personagens.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > Numero),
        };
        biju.Vilas = GetVilas();
        return biju;
    }

    public Vila GetVila(string Nome)
    {
        var vilas = GetVilas();
        return vilas.Where(t => t.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
        {
            _session.HttpContext.Session.SetString("Personagens", LerArquivo(personagemFile));
            _session.HttpContext.Session.SetString("Vilas", LerArquivo(vilasFile));
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


