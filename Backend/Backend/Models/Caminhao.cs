using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class Caminhao
	{
        [Key]
        public int Codigo { get; set; }
        [Precision(18, 2)]
        public decimal CapacidadeDeCarga { get; set; }

        public int CodigoVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}

