import { Component } from "@angular/core";
import { Shop } from "./services/shop.service";

@Component({
  selector: "theshop",
  templateUrl: "app.component.html",
  styleUrls: ["app.component.css"],
})
export class AppComponent {
  constructor(public shop: Shop) {}
  title = "VL";
}
