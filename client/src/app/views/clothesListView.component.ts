import { Component, OnInit } from "@angular/core";
import { Shop } from "../services/shop.service";

@Component({
    selector:'clotheslist',
    templateUrl: "clothesListView.component.html",
    styleUrls: ["clothesListView.component.css"]    
})
export default class ClothesListView implements OnInit {

    constructor(public shop: Shop) { 

    }


    ngOnInit(): void {
        this.shop.loadClothes().subscribe(() => {
            //do smth
        });
    }
}