import { Component } from "@angular/core";
import { Shop } from "../services/shop.service";

@Component({
    selector: 'cart',
    templateUrl: "cartView.component.html",
    styleUrls:["cartView.component.css"]
})
export class CartView{
    constructor(public shop: Shop) {

    }
}