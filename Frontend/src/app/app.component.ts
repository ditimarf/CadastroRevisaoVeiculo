import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ListaVeiculosComponent } from './lista-veiculos/lista-veiculos.component';
import { DetalhesVeiculoComponent } from "./detalhes-veiculo/detalhes-veiculo.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, ListaVeiculosComponent, DetalhesVeiculoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Frontend';
}
