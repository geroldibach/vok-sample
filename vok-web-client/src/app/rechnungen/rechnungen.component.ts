import { Component, OnInit } from '@angular/core';
import { RechnungStoreService, IRechnungAggregiert } from '../rechnung-store.service';

@Component({
  selector: 'app-rechnungen',
  templateUrl: './rechnungen.component.html',
  styleUrls: ['./rechnungen.component.css']
})
export class RechnungenComponent implements OnInit {
  public rechnungen: IRechnungAggregiert[];

  constructor(private rechnungStore: RechnungStoreService) { }

  ngOnInit() {
    this.loadRechnungen();
  }

  public loadRechnungen() {
    this.rechnungStore.loadRechnungen("Lieferant 128560")
      .forEach(re => this.rechnungen = re);
  }

}
