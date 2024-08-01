using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
	public class Carro
	{
        [Key]
        public int Codigo { get; set; }
        public int CapacidadePassageiro { get; set; }

        public int CodigoVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }
     }
}

