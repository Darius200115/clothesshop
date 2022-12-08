import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { Shop } from "./shop.service";

@Injectable()
export class AuthActivator implements CanActivate{
    constructor(private shop: Shop, private router: Router){

    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
    : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        if(this.shop.loginRequired){
            this.router.navigate(["login"]);
            return false;
        }else{
            return true;
        }
    }

}