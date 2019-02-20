import { CategoryDTO } from './../../../_services/swagger/SwaggerClient.service';
import { Injectable } from '@angular/core';
import { SwaggerClient } from 'src/app/_services/swagger/SwaggerClient.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private swagger: SwaggerClient) {}

  GetAllCategories() {
    // tslint:disable-next-line:max-line-length
    return this.swagger.api_Category_GetAll(
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

  DeleteCategory(Id: number) {
    return this.swagger.api_Category_Delete([Id]);
  }

  AddCategory(category: CategoryDTO) {
    return this.swagger.api_Category_Insert([category]);
  }

  UpdateCategory(category: CategoryDTO) {
    return this.swagger.api_Category_Update([category]);
  }

  GetCategoriesLookUp() {
    return this.swagger.api_LookupAll(
      'categories',
      undefined,
      undefined,
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
