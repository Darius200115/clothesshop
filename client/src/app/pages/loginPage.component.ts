import { Component } from "@angular/core";
import { Route, Router } from "@angular/router";
import { Shop } from "../services/shop.service";
import { LoginRequest } from "../shared/LoginResult";

@Component({
  selector: "loginPage",
  templateUrl: "loginPage.component.html",
})
export class LoginPage {
  constructor(private shop: Shop, private router: Router) {}

  public creds: LoginRequest = {
    username: "",
    password: "",
  };

  public ErrorMessage = "";

  onLogin() {
    this.shop.login(this.creds).subscribe({
      next: () => {
        //successfully logged in
        if (this.shop.order.items?.length! > 0) {
          this.router.navigate(["checkout"]);
        } else {
          this.router.navigate([""]);
        }
      },
      error: (err: any) => {
        console.log(err);
        this.ErrorMessage = "Failed to login!";
      },
    });
  }
}
