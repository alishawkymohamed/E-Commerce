import { Lookup } from './../../../_services/swagger/SwaggerClient.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Resolve } from '@angular/router';
import { CategoryService } from '../category-services/category-service.service';

@Injectable()
export class CategoryLookupResolver implements Resolve<Observable<Lookup[]>> {
  constructor(private categoryService: CategoryService) {}

  resolve() {
    return this.categoryService.GetCategoriesLookUp();
  }
}
