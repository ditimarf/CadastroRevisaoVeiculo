import { Component, OnInit } from '@angular/core';
import { VeiculoService } from '../veiculo.service';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { MatDialog } from '@angular/material/dialog';
import { DetalhesVeiculoComponent } from '../detalhes-veiculo/detalhes-veiculo.component';
import { Veiculo } from '../models/veiculo';

@Component({
  selector: 'app-lista-veiculos',
  standalone: true,
  imports: [NgIf, NgFor, FormsModule, NgxPaginationModule],
  templateUrl: './lista-veiculos.component.html',
  styleUrl: './lista-veiculos.component.css'
})
export class ListaVeiculosComponent implements OnInit {
  veiculos: any[] = []
  textoFiltro: string = ""
  pag: number = 1;
  contador: number = 8;

  constructor(private veiculoService: VeiculoService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.filtrarVeiculos()
  }

  filtrarVeiculos() {
    this.veiculoService.ObterVeiculos(this.textoFiltro).subscribe(data => {
      this.veiculos = data
    })
  }

  removerVeiculo(veiculo: Veiculo) {
    if (confirm(`Tem certeza que deseja remover o veículo ${veiculo.modelo}?`))
      this.veiculoService.RemoverVeiculo(veiculo.codigo).subscribe(data => {
        if (data) {
          alert("Veiculo removido com sucesso!")
          this.filtrarVeiculos()
        }
        else
          alert("Desculpe, houve um error ao tentar remover o veiculo.")
      })
  }

  editarVeiculo(veiculo: Veiculo) {
    this.dialog.open(DetalhesVeiculoComponent, { data: { veiculo: veiculo } });
  }

  criarVeiculo() {
    var modal = this.dialog.open(DetalhesVeiculoComponent, { data: { veiculo: null } })
    modal.afterClosed().subscribe(() => {
      if (modal.componentInstance.houveAlteracao)
        this.filtrarVeiculos()
    })
  }
}