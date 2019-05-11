import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductDTO, Lookup, SpecificationDTO } from 'src/app/_services/swagger/SwaggerClient.service';
import { ActivatedRoute } from '@angular/router';
import { SelectItem } from 'primeng/api';

@Component({
  selector: 'app-add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AddEditProductComponent implements OnInit {
  product: ProductDTO = new ProductDTO();
  categoryId = 0;
  allCategoriesLookup: Lookup[];
  CategoriesLookup: SelectItem[] = [];
  allSubCategoriesLookup: Lookup[];
  SubCategoriesLookup: SelectItem[] = [];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.product.specifications = this.product.specifications && this.product.specifications.length > 0
      ? this.product.specifications
      : [{} as SpecificationDTO];

    this.allCategoriesLookup = this.route.snapshot.data.CategoryLookup;
    this.allSubCategoriesLookup = this.route.snapshot.data.SubCategoryLookup;
    this.GetAllCategoriesLookup();
  }

  GetAllCategoriesLookup() {
    if (this.allCategoriesLookup && this.allCategoriesLookup.length) {
      this.allCategoriesLookup.forEach(value => {
        this.CategoriesLookup.push({
          label: value.textAr,
          value: value.id,
          title: value.textEn
        } as SelectItem);
      });
    }
  }

  GetAllSubCategoriesLookup() {
    if (this.allSubCategoriesLookup && this.allSubCategoriesLookup.length) {
      this.SubCategoriesLookup = [];
      this.allSubCategoriesLookup.filter(x => +x.additional.data === this.categoryId).forEach(value => {
        this.SubCategoriesLookup.push({
          label: value.textAr,
          value: value.id,
          title: value.textEn
        } as SelectItem);
      });
    }
  }

  categoryDropdownChanged(event) {
    this.categoryId = event.value;
    this.GetAllSubCategoriesLookup();
  }

  addSpec() {
    this.product.specifications.push({} as SpecificationDTO);
  }

  removeSpec(i: number) {
    if (this.product.specifications.length > 1) {
      this.product.specifications.splice(i, 1);
    }
  }

  onSubmit() {

  }
}
