import { DatePipe, NgFor, NgIf, registerLocaleData } from '@angular/common';
import { Component, Inject, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TipoVeiculoEnum } from '../enum/TipoVeiculoEnum';
import { Veiculo } from '../models/veiculo';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RevisaoService } from '../revisao.service';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { MY_DATE_FORMATS, MyDateAdapter } from '../../../date-format';
import localePt from '@angular/common/locales/pt';
import { MatIconModule } from '@angular/material/icon';
import { VeiculoService } from '../veiculo.service';
import { Carro } from '../models/carro';
import { Caminhao } from '../models/caminmhao';
import { ChangeDetectorRef } from '@angular/core';

registerLocaleData(localePt);

@Component({
  selector: 'app-detalhes-veiculo',
  standalone: true,
  imports: [FormsModule, NgIf, NgFor, MatDatepickerModule, MatFormFieldModule, MatInputModule, MatIconModule],
  providers: [
    DatePipe,
    { provide: DateAdapter, useClass: MyDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS },
    { provide: LOCALE_ID, useValue: 'pt-BR' }
  ],
  templateUrl: './detalhes-veiculo.component.html',
  styleUrl: './detalhes-veiculo.component.css'
})

export class DetalhesVeiculoComponent {
  TipoVeiculoEnum = TipoVeiculoEnum
  veiculo: Veiculo
  houveAlteracao: boolean = false

  capacidadePassageiros: number = 0
  capacidadeCarga: number = 0
  listaTiposVeiculo = [{ valor: TipoVeiculoEnum.Carro, descricao: "Carro" }, { valor: TipoVeiculoEnum.Caminhao, descricao: "Caminhão" }]
  ehUmNovoVeiculo: boolean = true
  caixaInsercaoRevisaoAberta: boolean = false

  quilometragemNovaRevisao: number = 0
  dataNovaRevisao: Date = new Date()
  valorNovaRevisao: number = 0

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: { veiculo: Veiculo | null },
    private revisaoService: RevisaoService,
    private veiculoService: VeiculoService,
    private datePipe: DatePipe,
    private cd: ChangeDetectorRef) {
    if (data?.veiculo) {
      this.veiculo = data.veiculo
      this.ehUmNovoVeiculo = false
      if(this.veiculo.carro)
      this.capacidadePassageiros = this.veiculo.carro.capacidadePassageiro
      if(this.veiculo.caminhao)
        this.capacidadeCarga = this.veiculo.caminhao.capacidadeCarga
    }
    else {
      this.veiculo = this.veiculo = new Veiculo(0, "", new Date().getFullYear(), "", "", null)
      this.ehUmNovoVeiculo = true
    }
  }

  salvarVeiculo() {
    if (!this.veiculoValidoParaSalvar())
      return;

    if (this.ehUmNovoVeiculo) {
      if (this.veiculo.tipoVeiculo == TipoVeiculoEnum.Carro) {
        this.veiculo.carro = new Carro(this.capacidadePassageiros)
        this.veiculo.caminhao = null
      }
      else {
        this.veiculo.carro = null
        this.veiculo.caminhao = new Caminhao(this.capacidadeCarga)
      }

      this.veiculoService.InserirVeiculo(this.veiculo).subscribe(novoVeiculo => {
        if (novoVeiculo) {
          this.veiculo = novoVeiculo;
          this.ehUmNovoVeiculo = false;
          alert("Veiculo salvo com sucesso")
          this.cd.detectChanges()
        }
      })
    }
    else {
      alert("Atualizacao")
    }

    this.houveAlteracao = true
  }

  veiculoValidoParaSalvar(): boolean {
    if (!this.veiculo.modelo) {
      alert("Insira o modelo do veiculo para poder salvar");
      return false;
    }
    else if (!this.veiculo.cor) {
      alert("Insira a cor do veiculo para poder salvar");
      return false;
    }
    if (this.veiculo.tipoVeiculo == null) {
      alert("Selecione o tipo do veiculo para poder salvar");
      return false;
    }
    else if (!this.veiculo.placa) {
      alert("Insira a placa do veiculo para poder salvar");
      return false;
    }
    else if (this.veiculo.tipoVeiculo == TipoVeiculoEnum.Carro && this.capacidadePassageiros <= 0) {
      alert("Insira a capacidade de passageiros do veiculo para poder salvar");
      return false;
    }
    else if (this.veiculo.tipoVeiculo == TipoVeiculoEnum.Caminhao && this.capacidadeCarga <= 0) {
      alert("Insira a capacidade de carga do veiculo para poder salvar");
      return false;
    }

    return true
  }

  transformDate(date: Date): string {
    var dataConvertida = this.datePipe.transform(date, 'dd/MM/yyyy');
    if (dataConvertida)
      return dataConvertida
    else
      return "-"
  }

  salvarRevisao() {
    this.revisaoService.InserirRevisao(this.veiculo.codigo, this.quilometragemNovaRevisao, this.dataNovaRevisao, this.valorNovaRevisao).subscribe(novaRevisao => {
      if (novaRevisao)
        this.veiculo.revisoes.push(novaRevisao);
    })
  }

  removerRevisao(codigoRevisao: number) {
    this.revisaoService.RemoverRevisao(codigoRevisao).subscribe(_ => {
      this.veiculo.revisoes = this.veiculo.revisoes.filter(x => x.codigo != codigoRevisao)
    })
  }
}