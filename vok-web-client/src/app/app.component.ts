import { Component } from '@angular/core';
import { Http } from  '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public lieferscheine: any[];

  constructor(private http: Http) { }

  public loadLieferscheine() {
    this.http.get("https://pcm-prototype.azurewebsites.net/api/lieferscheine")
      .forEach(response => {
        this.lieferscheine = (<any[]>response.json()).map(ls => {
          ls.liefertermin = new Date(ls.liefertermin);
          return ls;
        });
      });
  }
}
