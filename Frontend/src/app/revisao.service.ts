import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Revisao } from './models/revisao';

@Injectable({
  providedIn: 'root'
})

export class RevisaoService {
  private apiUrl = '/api/Revisao';

  constructor(private http: HttpClient) { }

  ObterRevisoesPorVeiculo(codigoVeiculo: number): Observable<Revisao[]> {
    return this.http.get<Revisao[]>(this.apiUrl + "?codigoVeiculo=" + codigoVeiculo);
  }

  InserirRevisao(codigoVeiculo: number, quilometragem: number, dataRevisao: Date, valorRevisao: number): Observable<Revisao> {
    return this.http.post<Revisao>(this.apiUrl, { codigoVeiculo, quilometragem, dataRevisao, valorRevisao });
  }

  RemoverRevisao(codigoRevisao: number): Observable<any> {
    return this.http.delete<any>(this.apiUrl + "?codigoRevisao=" + codigoRevisao);
  }
}
