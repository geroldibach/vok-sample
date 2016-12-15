import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

export interface IRechnungAggregiert {
  lieferantenname: string;
  rechnungsnummer: string;
  betrag: number;
  dokumentName: string;
}

@Injectable()
export class RechnungStoreService {

  constructor(private http: Http) { }

  public loadRechnungen(lieferantenname: string) : Observable<IRechnungAggregiert[]> {
    return this.http.get(`https://pcm-prototype.azurewebsites.net/api/rechnungen?lieferantenname=${lieferantenname}`)
      .map(response => (<IRechnungAggregiert[]>response.json()));
  }
}