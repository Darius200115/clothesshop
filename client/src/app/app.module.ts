import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { Shop } from './services/shop.service';
import ClothesListView from './views/clothesListView.component';
import { CartView } from './views/cartView.component';
import { ShopPage } from './pages/shopPage.component';
import { CheckoutPage } from './pages/ckeckout.component';
import router from './router';


@NgModule({
  declarations: [
        AppComponent,
        ClothesListView,
        CartView,   
        ShopPage,
        CheckoutPage
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      router
  ],
    providers: [
        Shop
        ],
  bootstrap: [AppComponent]
})
export class AppModule { }
