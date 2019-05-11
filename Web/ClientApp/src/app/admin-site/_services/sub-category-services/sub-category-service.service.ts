import { Injectable } from '@angular/core';
import {
  SwaggerClient,
  SubCategoryDTO
} from 'src/app/_services/swagger/SwaggerClient.service';

@Injectable({
  providedIn: 'root'
})
export class SubCategoryService {
  constructor(private swagger: SwaggerClient) { }

  GetAllSubCategories() {
    // tslint:disable-next-line:max-line-length
    return this.swagger.api_SubCategory_GetAll(
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

  DeleteSubCategory(Id: number) {
    return this.swagger.api_SubCategory_Delete([Id]);
  }

  AddSubCategory(category: SubCategoryDTO) {
    return this.swagger.api_SubCategory_Insert([category]);
  }

  UpdateSubCategory(category: SubCategoryDTO) {
    return this.swagger.api_SubCategory_Update([category]);
  }

  GetSubCategoriesLookUp() {
    return this.swagger.api_LookupAll(
      'subcategories',
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
