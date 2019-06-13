import { Injectable } from '@angular/core';
import { SwaggerClient, ProductDTO } from 'src/app/_services/swagger/SwaggerClient.service';

@Injectable({ providedIn: 'root' })
export class ProductService {

    constructor(private swagger: SwaggerClient) { }

    AddProduct(products: ProductDTO[]) {
        return this.swagger.api_Product_Insert(products);
    }

    GetAllProducts(subCategoryId: number) {
        if (subCategoryId) {
            return this.swagger.api_Product_GetAllOfSubCategory(subCategoryId, undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                undefined);
        } else {
            return this.swagger.api_Product_GetAll(
                undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                undefined
            );
        }
    }

    DeleteProduct(productId: number) {
        return this.swagger.api_Product_Delete([productId]);
    }
}