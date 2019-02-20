import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import {
  SubCategoryDTO,
  Lookup,
  CategoryDTO
} from 'src/app/_services/swagger/SwaggerClient.service';
import { DynamicDialogRef, DynamicDialogConfig, SelectItem } from 'primeng/api';

@Component({
  selector: 'app-add-edit-sub-category',
  templateUrl: './add-edit-sub-category.component.html',
  styleUrls: ['./add-edit-sub-category.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AddEditSubCategoryComponent implements OnInit {
  subCategory: SubCategoryDTO;
  allCategoriesLookup: Lookup[];
  CategoriesLookup: SelectItem[] = [];
  submitted = false;
  categoryId = null;

  constructor(
    private ref: DynamicDialogRef,
    private config: DynamicDialogConfig
  ) {
    this.subCategory = this.config.data.SubCategory
      ? this.config.data.SubCategory
      : new SubCategoryDTO();
    this.allCategoriesLookup = this.config.data.CategoriesLookup
      ? this.config.data.CategoriesLookup
      : [];
  }

  ngOnInit() {
    this.allCategoriesLookup.forEach(value => {
      this.CategoriesLookup.push({
        label: value.textAr,
        value: value.id,
        title: value.textEn
      } as SelectItem);
    });
  }

  onSubmit() {
    this.submitted = true;
    this.ref.close(this.subCategory);
  }
}
