import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { Shop } from "./services/shop.service";
import ClothesListView from "./views/clothesListView.component";
import { CartView } from "./views/cartView.component";
import { ShopPage } from "./pages/shopPage.component";
import { CheckoutPage } from "./pages/ckeckout.component";
import router from "./router";
import { LoginPage } from "./pages/loginPage.component";
import { AuthActivator } from "./services/authActivator.service";
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    ClothesListView,
    CartView,
    ShopPage,
    CheckoutPage,
    LoginPage,
  ],
  imports: [BrowserModule, HttpClientModule, router, FormsModule],
  providers: [Shop, AuthActivator],
  bootstrap: [AppComponent],
})
export class AppModule {}
