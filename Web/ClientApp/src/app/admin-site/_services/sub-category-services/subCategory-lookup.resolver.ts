import { Lookup } from './../../../_services/swagger/SwaggerClient.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Resolve } from '@angular/router';
import { CategoryService } from '../category-services/category-service.service';
import { SubCategoryService } from './sub-category-service.service';

@Injectable()
export class SubCategoryLookupResolver implements Resolve<Observable<Lookup[]>> {
    constructor(private subCategoryService: SubCategoryService) { }

    resolve() {
        return this.subCategoryService.GetSubCategoriesLookUp();
    }
}
