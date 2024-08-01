using System.Net;
using System.Net.Http.Json;
using Backend.Models;

namespace TesteBackend;

public class Tests
{
    [Test]
    public async Task GET_Retorna_Todas_Categorias()
    {
        await using var application = new TesteGolApplication();

        await TesteGolMockData.CriarVeiculos(application, true);
        var url = "/api/Veiculo";

        var client = application.CreateClient();

        var result = await client.GetAsync(url);
        var veiculos = await client.GetFromJsonAsync<List<Veiculo>>(url);

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.IsNotNull(veiculos);
        Assert.IsTrue(veiculos.Count == 2);
    }
}
