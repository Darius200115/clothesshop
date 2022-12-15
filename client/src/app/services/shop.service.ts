import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Clothes } from "../shared/Clothes";
import { LoginRequest, LoginResult } from "../shared/LoginResult";
import { Order, OrderItem } from "../shared/Order";

@Injectable()
export class Shop {
  constructor(private http: HttpClient) {}

  public clothes: Clothes[] = [];
  public newclothes: Clothes = new Clothes();
  public order: Order = new Order();

  public token = "";
  public expiration = new Date();

  get loginRequired(): boolean {
    return this.token.length === 0 || this.expiration > new Date();
  }

  loadClothes(): Observable<void> {
    return this.http.get<[]>("/api/clothes").pipe(
      map((data) => {
        this.clothes = data;
        return;
      })
    );
  }

  add(clothes: Clothes) {
    return this.http.post<Clothes>("/api/clothes", clothes).pipe(
      map(() => {
        this.newclothes = new Clothes();
      })
    );
  }

  login(creds: LoginRequest) {
    return this.http.post<LoginResult>("/api/account", creds).pipe(
      map((data) => {
        this.token = data.token;
        this.expiration = data.expiration;
      })
    );
  }

  checkout() {
    const headers = new HttpHeaders().set(
      "Authorization",
      `Bearer ${this.token}`
    );

    return this.http
      .post("/api/orders", this.order, {
        headers: headers,
      })
      .pipe(
        map(() => {
          this.order = new Order();
        })
      );
  }



  addToOrder(clothes: Clothes) {
    let item: OrderItem;

    item = this.order.items?.find((o) => o.clothesId === clothes.clothesId)!;

    if (item) {
      item.quantity++;
    } else {
      item = new OrderItem();
      item.clothesId = clothes.clothesId;
      item.brand = clothes.brand;
      item.category = clothes.category;
      item.count = clothes.count;
      item.quantity = 1;
      item.unitPrice = clothes.price;
      item.pictureUrl = clothes.pictureUrl;

      this.order.items?.push(item);
    }
  }
}
