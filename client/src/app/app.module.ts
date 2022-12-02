import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { Shop } from './services/shop.service';
import ClothesListView from './views/clothesListView.component';

@NgModule({
  declarations: [
        AppComponent,
        ClothesListView
  ],
  imports: [
      BrowserModule,
      HttpClientModule
  ],
    providers: [
        Shop
        ],
  bootstrap: [AppComponent]
})
export class AppModule { }
