using Backend.Enums;

namespace Backend.DTO
{
    public class InserirVeiculoDTO
	{
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int TipoVeiculo { get; set; }
        public CarroDTO? Carro { get; set; }
        public CaminhaoDTO? Caminhao { get; set; }
    }
}

