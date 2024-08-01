using System.ComponentModel.DataAnnotations;
using Backend.Enums;

namespace Backend.Models
{
    public class Veiculo
	{
        [Key]
        public int Codigo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public TipoVeiculoEnum TipoVeiculo { get; set; }

        public virtual Carro? Carro { get; set; }
        public virtual Caminhao? Caminhao { get; set; }
        public List<Revisao>? Revisoes { get; set; }
    }
}

