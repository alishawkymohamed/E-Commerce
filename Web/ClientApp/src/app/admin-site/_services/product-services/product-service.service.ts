import { Injectable } from '@angular/core';
import { SwaggerClient, ProductDTO } from 'src/app/_services/swagger/SwaggerClient.service';

@Injectable({ providedIn: 'root' })
export class ProductService {

    constructor(private swagger: SwaggerClient) { }

    AddProduct(products: ProductDTO[]) {
        return this.swagger.api_Product_Insert(products);
    }
}