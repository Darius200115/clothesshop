import { Component } from "@angular/core";
import { Route, Router } from "@angular/router";
import { Shop } from "../services/shop.service";

@Component({
    selector: 'loginPage',
    templateUrl:"loginPage.component.html"   
})
export class LoginPage{
constructor(private shop: Shop, private router: Router ){   
}
public creds ={
    username: "", 
    password: ""
}
onLogin(){
    alert("Logging in...");
}

}