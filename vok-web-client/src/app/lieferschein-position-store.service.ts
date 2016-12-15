import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

export interface ILieferscheinPosition {
  dsid: number;
  lieferscheinID: number;
  lieferscheinPositionID: number;
  netto: number;
  brutto: number;
  artikelbezeichnung: string;
  lieferantenmaterialnummer: string;
}

@Injectable()
export class LieferscheinPositionStoreService {

  constructor(private http: Http) { }

  public loadLieferscheine(lieferscheinIDs: number[]) : Observable<ILieferscheinPosition[]> {
    return this.http.post("https://pcm-prototype.azurewebsites.net/api/lieferscheinPositionen", lieferscheinIDs)
      .map(response => (<ILieferscheinPosition[]>response.json()));
  }
}
