import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Lookup, ProductDTO } from 'src/app/_services/swagger/SwaggerClient.service';
import { SelectItem } from 'primeng/api';
import { ProductService } from '../_services/product-services/product-service.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  allCategoriesLookup: Lookup[];
  allSubCategoriesLookup: Lookup[];
  allProducts: ProductDTO[];
  categoriesSelectItems: SelectItem[] = [];
  subCategoriesSelectItems: SelectItem[] = [];
  selectedCategory: number;
  selectedSubCategory: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductService,
    private translateService: TranslateService) { }

  ngOnInit() {
    this.GetAllCategoriesLookup();
    this.GetAllSubCategoriesLookup();
  }

  GetAllCategoriesLookup() {
    this.allCategoriesLookup = this.route.snapshot.data.CategoryLookup;
    this.allCategoriesLookup.forEach(value => {
      this.categoriesSelectItems.push({
        label: value.textAr,
        value: value.id,
        title: value.textEn
      } as SelectItem);
    });
    this.translateService.get("All").subscribe(res => {
      this.categoriesSelectItems.push({
        label: res,
        value: 0,
        title: res
      } as SelectItem);
    });
  }

  GetAllSubCategoriesLookup() {
    this.allSubCategoriesLookup = this.route.snapshot.data.SubCategoryLookup;
    this.allSubCategoriesLookup.forEach(value => {
      this.subCategoriesSelectItems.push({
        label: value.textAr,
        value: value.id,
        title: value.textEn
      } as SelectItem);
    });
  }

  CategoryChanged() {
    this.subCategoriesSelectItems = [];
    if (this.selectedCategory === 0) {
      this.selectedSubCategory = null;
      this.GetAllProducts(this.selectedSubCategory);
    } else {
      this.allSubCategoriesLookup.filter(x => x.additional.data === this.selectedCategory).forEach(value => {
        this.subCategoriesSelectItems.push({
          label: value.textAr,
          value: value.id,
          title: value.textEn
        } as SelectItem);
      });
    }
  }

  SubCategoryChanged() {
    this.GetAllProducts(this.selectedSubCategory);
  }

  GetAllProducts(subCategoryId: number) {
    // TODO Open Loading
    this.productService.GetAllProducts(subCategoryId).subscribe(data => {
      if (data.data && data.count) {
        this.allProducts = data.data;
      }
    }, error => {
      console.log(error);
    }, () => {
      // TODO Close Lodding;
    });
  }

  gotoAddEditComponent() {
    this.router.navigate(['admin', 'product', 'add']);
  }
}
