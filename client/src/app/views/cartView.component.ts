import { Component } from "@angular/core";
import { Shop } from "../services/shop.service";
import { faCartShopping } from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: "cart",
  templateUrl: "cartView.component.html",
  styleUrls: ["cartView.component.css"],
})
export class CartView {
  constructor(public shop: Shop) {}
  
  page: number=1;
  faCartShopping = faCartShopping;
}
