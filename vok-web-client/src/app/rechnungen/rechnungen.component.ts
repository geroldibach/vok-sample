import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { RechnungStoreService, IRechnungAggregiert } from '../rechnung-store.service';

@Component({
  selector: 'app-rechnungen',
  templateUrl: './rechnungen.component.html',
  styleUrls: ['./rechnungen.component.css']
})
export class RechnungenComponent implements OnChanges {
  @Input() public lieferantenname: string;

  public rechnungen: IRechnungAggregiert[];

  constructor(private rechnungStore: RechnungStoreService) { }

  ngOnChanges(changes: SimpleChanges) {
    const lieferantennameChange = changes["lieferantenname"]; 
    if (lieferantennameChange.currentValue !== lieferantennameChange.previousValue) {
      this.loadRechnungen(lieferantennameChange.currentValue);
    }
  }

  public loadRechnungen(lieferantenname: string) {
    this.rechnungStore.loadRechnungen(lieferantenname)
      .forEach(re => this.rechnungen = re);
  }
}
