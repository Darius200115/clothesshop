import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Clothes } from "../shared/Clothes";

@Injectable()
export class Shop {

    constructor(private http: HttpClient) {

    }


    public clothes: Clothes[] = [];

    loadClothes(): Observable<void> {
        return this.http.get<[]>("/api/clothes")
            .pipe(map(data => {
                this.clothes = data;
                return;
            }));
    }
}