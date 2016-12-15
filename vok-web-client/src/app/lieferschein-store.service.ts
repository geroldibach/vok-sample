import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

export interface ILieferscheinAggregiert {
  dsid: number;
  lieferscheinnummer: string;
  lieferantenname: string;
  liefertermin: Date;
  summeNetto: number;
  summeBrutto: number;
}

@Injectable()
export class LieferscheinStoreService {

  constructor(private http: Http) { }

  public loadLieferscheine() : Observable<ILieferscheinAggregiert[]> {
    return this.http.get("https://pcm-prototype.azurewebsites.net/api/lieferscheine")
      .map(response => (<ILieferscheinAggregiert[]>response.json()).map(ls => {
          // Web API returns string -> convert it to Date
          ls.liefertermin = new Date(<any>ls.liefertermin);
          return ls;
        })
      );
  }
}
