import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Shop } from "../services/shop.service";

@Component({
  selector: "checkout",
  templateUrl: "checkout.component.html",
  styleUrls: ["checkout.component.css"],
})
export class CheckoutPage {
  public errorMessage = "";

  constructor(public shop: Shop, private router: Router) {}
  onCheckout() {
    this.errorMessage = "";
    this.shop.checkout().subscribe({
      next: () => {
        this.router.navigate(["/"]);
        alert("Purchase success");
      },
      error: (err: any) => {
        this.errorMessage = `Failed to checkout: ${err}`;
      },
    });
  }
}
