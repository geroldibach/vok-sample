import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { LieferscheinStoreService, ILieferscheinAggregiert } from '../lieferschein-store.service';

@Component({
  selector: 'app-lieferscheine',
  templateUrl: './lieferscheine.component.html',
  styleUrls: ['./lieferscheine.component.css']
})
export class LieferscheineComponent implements OnInit {
  @Output() public lieferantenname = new EventEmitter();
  public lieferscheine: ILieferscheinAggregiert[];

  constructor(private lieferscheinStore: LieferscheinStoreService) { }

  ngOnInit() {
    this.loadLieferscheine();
  }

  public loadLieferscheine() {
    this.lieferscheinStore.loadLieferscheine()
      .forEach(ls => this.lieferscheine = ls);
  }

  public selectLieferschein(lieferschein: ILieferscheinAggregiert) {
    this.lieferantenname.next([lieferschein.lieferantenname]);
  }
}
