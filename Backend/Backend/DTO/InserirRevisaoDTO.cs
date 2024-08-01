namespace Backend.DTO
{
    public class InserirRevisaoDTO
	{
		public int CodigoVeiculo { get; set; }
        public int Quilometragem { get; set; }
        public DateTime DataRevisao { get; set; }
        public decimal ValorRevisao { get; set; }
    }
}

