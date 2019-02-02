import { Injectable } from '@angular/core';
import { SwaggerClient } from 'src/app/_services/swagger/SwaggerClient.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor (private swagger: SwaggerClient) {

  }

  GetAllCategories() {
    // tslint:disable-next-line:max-line-length
    return this.swagger.api_Category_GetAll(undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined);
  }
}
