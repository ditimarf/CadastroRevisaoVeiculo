﻿using Backend.Models;
using Backend.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace TesteBackend
{
    public class TesteGolMockData
    {
        public static async Task CriarVeiculos(TesteGolApplication application, bool criar)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var catalogoDbContext = provider.GetRequiredService<AppDBContext>())
                {
                    await catalogoDbContext.Database.EnsureCreatedAsync();

                    if (criar)
                    {
                        await catalogoDbContext.Veiculo.AddAsync(new Veiculo
                        {
                            Codigo = 10,
                            Ano = 2017,
                            Cor = "Vemelho",
                            Modelo = "L200 Triton",
                            Placa = "XXX-0000",
                            TipoVeiculo = Backend.Enums.TipoVeiculoEnum.Carro,
                            Carro = new Carro
                            {
                                CapacidadePassageiro = 5
                            },
                            Revisoes = new List<Revisao>
                            {
                                new Revisao { CodigoVeiculo = 10, DataRevisao = DateTime.Now, Quilometragem = 75000, ValorRevisao = 550 },
                                new Revisao { CodigoVeiculo = 10, DataRevisao = DateTime.Now, Quilometragem = 79000, ValorRevisao = 200 },
                                new Revisao { CodigoVeiculo = 10, DataRevisao = DateTime.Now, Quilometragem = 83000, ValorRevisao = 175 },
                            }
                        });

                        await catalogoDbContext.Veiculo.AddAsync(new Veiculo
                        {
                            Ano = 2017,
                            Cor = "Vemelho",
                            Modelo = "Mercedinha 715",
                            Placa = "XXX-0000",
                            TipoVeiculo = Backend.Enums.TipoVeiculoEnum.Caminhao,
                            Caminhao = new Caminhao
                            {
                                CapacidadeDeCarga = 5000
                            }
                        });

                        await catalogoDbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}

