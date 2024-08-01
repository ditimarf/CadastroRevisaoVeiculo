import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Veiculo } from './models/veiculo';

@Injectable({
  providedIn: 'root'
})

export class VeiculoService {
  private apiUrl = '/api/Veiculo';

  constructor(private http: HttpClient) { }

  ObterVeiculos(filtro: string = ""): Observable<Veiculo[]> {
    return this.http.get<Veiculo[]>(this.apiUrl + "?Filtro=" + filtro);
  }

  InserirVeiculo(veiculo: Veiculo): Observable<Veiculo> {
    return this.http.post<Veiculo>(this.apiUrl, veiculo);
  }

  RemoverVeiculo(codigoVeiculo:number): Observable<boolean>{
    return this.http.delete<boolean>(this.apiUrl + "?codigoVeiculo="+ codigoVeiculo);
  }
}
