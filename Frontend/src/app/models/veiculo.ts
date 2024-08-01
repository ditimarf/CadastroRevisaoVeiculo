import { TipoVeiculoEnum } from "../enum/TipoVeiculoEnum"
import { Caminhao } from "./caminhao"
import { Carro } from "./carro"
import { Revisao } from "./revisao"

export class Veiculo{
    carro:Carro|null = null
    caminhao:Caminhao| null = null
    revisoes:Revisao[] = []
    
    constructor(
        public codigo:number, 
        public modelo:string, 
        public ano:number, 
        public cor:string, 
        public placa:string,
        public tipoVeiculo:TipoVeiculoEnum | null){
    }
}