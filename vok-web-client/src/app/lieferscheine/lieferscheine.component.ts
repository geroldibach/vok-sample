import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { LieferscheinStoreService, ILieferscheinAggregiert } from '../lieferschein-store.service';

interface ISelectableLieferschein extends ILieferscheinAggregiert {
  selected?: boolean;
  selectable?: boolean;
}

@Component({
  selector: 'app-lieferscheine',
  templateUrl: './lieferscheine.component.html',
  styleUrls: ['./lieferscheine.component.css']
})
export class LieferscheineComponent implements OnInit {
  @Output() public lieferantenname = new EventEmitter();
  @Output() public lieferscheinIDs = new EventEmitter();
  public lieferscheine: ISelectableLieferschein[];

  constructor(private lieferscheinStore: LieferscheinStoreService) { }

  ngOnInit() {
    this.loadLieferscheine();
  }

  public loadLieferscheine() {
    this.lieferscheinStore.loadLieferscheine()
      .forEach(ls => this.lieferscheine = ls);
  }

  public selectLieferschein(lieferschein: ISelectableLieferschein) {
    if (lieferschein.selected) {
      // Unselecting
      lieferschein.selected = false;

      let selectedLieferscheine = this.lieferscheine.filter(ls => ls.selected).map(ls => ls.dsid);
      if (selectedLieferscheine.length == 0) {
        this.lieferantenname.next([""]);
      }

      this.lieferscheinIDs.next([selectedLieferscheine]);
    }
    else {
      // Selecting
      let selectedLieferscheine = this.lieferscheine.filter(ls => ls.selected);
      if (selectedLieferscheine.length > 0) {
        if (selectedLieferscheine[0].lieferantenname != lieferschein.lieferantenname) {
          // ToDo: Display warning message to user
          return;
        }
      }

      lieferschein.selected = true;
      this.lieferantenname.next([lieferschein.lieferantenname]);
      this.lieferscheinIDs.next([this.lieferscheine.filter(ls => ls.selected).map(ls => ls.dsid)]);
    }
  }
}
