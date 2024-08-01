using System.Net;
using System.Net.Http.Json;
using Backend.Models;

namespace TesteBackend;

public class Tests
{
    [Test]
    public async Task GET_RetornaTodosOsVeiculos()
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

    [Test]
    public async Task GET_RetornaVeiculosFiltrados()
    {
        await using var application = new TesteGolApplication();

        await TesteGolMockData.CriarVeiculos(application, true);
        var url = "/api/Veiculo?filtro=Triton";

        var client = application.CreateClient();

        var result = await client.GetAsync(url);
        var veiculos = await client.GetFromJsonAsync<List<Veiculo>>(url);

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.IsNotNull(veiculos);
        Assert.IsTrue(veiculos.Count == 1);
    }

    //Como nao foi criado um endpoint para retornar as revisoes, vou usar o para pegar todos os veiculos e filtrar
    [TestCase(10, 3, true)]
    [TestCase(99, 0, false)]
    public async Task GET_RetornaTodosOsVeiculosVerificandoRevisao(int codigoVeiculo, int quantidadeRevisoes, bool veiculoExiste)
    {
        await using var application = new TesteGolApplication();

        await TesteGolMockData.CriarVeiculos(application, true);
        var url = "/api/Veiculo";

        var client = application.CreateClient();

        var result = await client.GetAsync(url);
        var veiculos = await client.GetFromJsonAsync<List<Veiculo>>(url);
        var veiculo = veiculos!.FirstOrDefault(x => x.Codigo == 10);

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        if (veiculoExiste)
            Assert.IsNotNull(veiculo);
        Assert.IsTrue(veiculo!.Revisoes!.Count == 3);
    }

    [Test]
    public async Task POST_InserirVeiculo()
    {
        await using var application = new TesteGolApplication();

        await TesteGolMockData.CriarVeiculos(application, true);
        var url = "/api/Veiculo";

        var client = application.CreateClient();

        var result = await client.PostAsJsonAsync(url, new
        {
            placa = "PlacaTeste",
            Ano = 2012,
            Modelo = "ModeloTeste",
            Cor = "CorTeste",
            tipoVeiculo = 1,
            carro = new { capacidadePassageiro = 5}
        });

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task POST_InserirVeiculoObjetoInvalido()
    {
        await using var application = new TesteGolApplication();

        await TesteGolMockData.CriarVeiculos(application, true);
        var url = "/api/Veiculo";

        var client = application.CreateClient();

        var result = await client.PostAsJsonAsync(url, new
        {
            placa = "PlacaTeste",
            Ano = 2012,
            Modelo = "ModeloTeste",
            Cor = "CorTeste",
            tipoVeiculo = 1,
            caminhao = new { capacidadePassageiro = 5 }
        });

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}
