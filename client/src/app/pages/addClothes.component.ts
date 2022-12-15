import { Component } from "@angular/core";
import { Router, Route } from "@angular/router";
import { Shop } from "../services/shop.service";
import { Clothes } from "../shared/Clothes";

@Component({
  selector: "form-newClothes",
  templateUrl: "addClothes.component.html",
  styleUrls: ["addClothes.component.css"],
})
export class AddClothes {
  constructor(public shop: Shop, private router: Router) {}

  public clothes: Clothes = {
    clothesId: 0,
    brand: "",
    category: "",
    size: "",
    price: 0,
    countryManufacturer: "",
    description: "",
    pictureUrl: "",
    count: 0,
    deliveryDate: new Date(),
  };

  errorMessage = "";

  onAdd() {
    this.errorMessage = "";
    this.shop.add(this.clothes).subscribe({
      next: () => {
        this.router.navigate(["/"]);
        alert("Operation success");
      },
      error: (err: any) => {
        this.errorMessage = `Failed to adding new clothes: ${err}`;
      },
    });
  }
}
