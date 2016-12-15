import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';

import { GridModule } from '@progress/kendo-angular-grid';
import { LieferscheineComponent } from './lieferscheine/lieferscheine.component';
import { LieferscheinStoreService } from './lieferschein-store.service';
import { RechnungStoreService } from './rechnung-store.service';
import { RechnungenComponent } from './rechnungen/rechnungen.component';
import { LieferscheinPositionenComponent } from './lieferschein-positionen/lieferschein-positionen.component';
import { LieferscheinPositionStoreService } from './lieferschein-position-store.service';

@NgModule({
  declarations: [
    AppComponent,
    LieferscheineComponent,
    RechnungenComponent,
    LieferscheinPositionenComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,

    GridModule
  ],
  providers: [
    LieferscheinStoreService,
    RechnungStoreService,
    LieferscheinPositionStoreService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
