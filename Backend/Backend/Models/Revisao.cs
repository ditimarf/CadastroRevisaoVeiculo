using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.Models
{
    public class Revisao
	{
		[Key]
		public int Codigo { get; set; }
		public int Quilometragem { get; set; }
		public DateTime DataRevisao { get; set; }
        [Precision(18,2)]
        public decimal ValorRevisao { get; set; }

		public int CodigoVeiculo { get; set; }
		public Veiculo Veiculo { get; set; }
    }
}

