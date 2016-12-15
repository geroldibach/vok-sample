import { Component, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public lieferantenname: string;

  constructor() { }

  onLieferantennameChanged(parameter: any) {
    this.lieferantenname = parameter[0];
  }
}
