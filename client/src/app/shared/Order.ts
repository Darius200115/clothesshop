export class OrderItem {
  id: number;
  quantity: number;
  unitPrice: number;
  clothesId: number;
  brand: string;
  category: string;
  price: number;
  count: number;
  pictureUrl: string;
  size: string;
}

export class Order {
  orderId: number;
  orderDate: Date = new Date();
  orderNumber: string = Math.random().toString(36).substr(2, 10);
  items?: OrderItem[] = [];

  get subtotal(): number {
    const result = this.items?.reduce((total, value) => {
      return total + value.unitPrice * value.quantity;
    }, 0);
    return result!;
  }
}
