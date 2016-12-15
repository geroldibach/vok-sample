import { Component, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public lieferantenname: string;
  public lieferscheinIDs: number[];

  constructor() { }

  onLieferantennameChanged(parameter: any) {
    this.lieferantenname = parameter[0];
  }

  onLieferscheinIDsChanged(parameter: any) {
    this.lieferscheinIDs = parameter[0];
  }
}
