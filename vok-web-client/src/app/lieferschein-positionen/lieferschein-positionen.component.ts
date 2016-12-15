import { Component, OnInit, Input, SimpleChanges, OnChanges } from '@angular/core';
import { LieferscheinPositionStoreService, ILieferscheinPosition } from '../lieferschein-position-store.service';

@Component({
  selector: 'app-lieferschein-positionen',
  templateUrl: './lieferschein-positionen.component.html',
  styleUrls: ['./lieferschein-positionen.component.css']
})
export class LieferscheinPositionenComponent implements OnChanges {
  @Input() public lieferscheinIDs: number[];

  public lieferscheinPositionen: ILieferscheinPosition[];

  constructor(private lieferscheinPositionStore: LieferscheinPositionStoreService) { }

  ngOnChanges(changes: SimpleChanges) {
    const lieferscheinIDs = <number[]>changes["lieferscheinIDs"].currentValue;
    if (!lieferscheinIDs || lieferscheinIDs.length === 0) {
      this.lieferscheinPositionen = null;
    }
    else {
      this.loadLieferscheinPositionen(lieferscheinIDs);
    }
  }

  public loadLieferscheinPositionen(lieferscheinIDs: number[]) {
    this.lieferscheinPositionStore.loadLieferscheine(lieferscheinIDs)
      .forEach(re => this.lieferscheinPositionen = re);
  }
}
