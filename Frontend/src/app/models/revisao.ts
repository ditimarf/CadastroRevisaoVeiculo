export class Revisao{
    constructor(
        public codigo:number,
        public codigoVeiculo:number,
        public quilometragem:number,
        public dataRevisao:Date,
        public valorRevisao:number
    ){}
}