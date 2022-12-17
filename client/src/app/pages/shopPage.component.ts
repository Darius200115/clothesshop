import { Component } from "@angular/core";
import { Shop } from "../services/shop.service";

@Component({
  selector: "shopPage",
  templateUrl: "shopPage.component.html",
  styleUrls: ["shopPage.component.css"],
})
export class ShopPage {
  constructor(public shop: Shop) {}
  title = "ShopPage";
}
