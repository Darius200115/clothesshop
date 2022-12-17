import { RouterModule } from "@angular/router";
import { AddClothes } from "../pages/addClothes.component";
import { CheckoutPage } from "../pages/ckeckout.component";
import { LoginPage } from "../pages/loginPage.component";
import { ShopPage } from "../pages/shopPage.component";
import { AuthActivator } from "../services/authActivator.service";

const routes = [
  { path: "", component: ShopPage },
  { path: "checkout", component: CheckoutPage, canActivate: [AuthActivator] },
  { path: "login", component: LoginPage },
  { path: "add", component: AddClothes },
  { path: "**", redirectTo: "/" },
];

const router = RouterModule.forRoot(routes, {
  useHash: false,
});

export default router;
