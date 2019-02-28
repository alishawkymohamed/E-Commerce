import { Component, OnInit } from '@angular/core';
import {
  SubCategoryDTO,
  Lookup
} from 'src/app/_services/swagger/SwaggerClient.service';
import { TranslateService } from '@ngx-translate/core';
import {
  MessageService,
  DialogService,
  ConfirmationService
} from 'primeng/api';
import { SubCategoryService } from '../_services/sub-category-services/sub-category-service.service';
import { AddEditSubCategoryComponent } from './add-edit-sub-category/add-edit-sub-category.component';
import { CategoryService } from '../_services/category-services/category-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sub-category',
  templateUrl: './sub-category.component.html',
  styleUrls: ['./sub-category.component.scss']
})
export class SubCategoryComponent implements OnInit {
  allSubCategories: SubCategoryDTO[];
  allCategoriesLookup: Lookup[];
  constructor(
    private subcategoryService: SubCategoryService,
    private categoryService: CategoryService,
    private translateService: TranslateService,
    private toastService: MessageService,
    public dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.GetAllSubCategories();
    this.GetAllCategoriesLookup();
  }

  GetAllSubCategories() {
    this.subcategoryService.GetAllSubCategories().subscribe(data => {
      if (data) {
        this.allSubCategories = data.data;
      }
    });
  }

  GetAllCategoriesLookup() {
    this.allCategoriesLookup = this.route.snapshot.data.CategoryLookup;
  }

  DeleteSubCategory(Id: number) {
    this.subcategoryService.DeleteSubCategory(Id).subscribe(
      data => {
        if (data && data.length) {
          this.GetAllSubCategories();
          this.translateService
            .get('DeletedSuccess')
            .subscribe((res: string) => {
              this.toastService.add({
                severity: 'success',
                life: 3000,
                closable: true,
                summary: res
              });
            });
        }
      },
      error => {
        this.translateService.get('DeletedFail').subscribe((res: string) => {
          this.toastService.add({
            severity: 'info',
            life: 3000,
            closable: true,
            summary: res
          });
        });
      }
    );
  }

  confirmDelete(SubcategoryId: number) {
    this.confirmationService.confirm({
      message: null,
      header: null,
      icon: 'pi pi-info-circle',
      accept: () => {
        this.DeleteSubCategory(SubcategoryId);
      },
      reject: () => {
        this.translateService.get('DeletedFail').subscribe((res: string) => {
          this.toastService.add({
            severity: 'info',
            life: 3000,
            closable: true,
            summary: res
          });
        });
      }
    });
  }

  showAddEditComponent(SubCategory: SubCategoryDTO) {
    this.translateService
      .get(['Create', 'Update', 'SubCategory'])
      .subscribe((res: any) => {
        const ref = this.dialogService.open(AddEditSubCategoryComponent, {
          header:
            SubCategory != null
              ? `${res['Update']} ${res['SubCategory']}`
              : `${res['Create']} ${res['SubCategory']}`,
          data: {
            SubCategory: Object.assign({}, SubCategory),
            CategoriesLookup: Object.assign([], this.allCategoriesLookup)
          }
        });

        ref.onClose.subscribe((cat: SubCategoryDTO) => {
          if (cat && !cat.subCategoryId) {
            this.AddSubCategory(cat);
          } else if (cat && cat.subCategoryId) {
            this.UpdateSubCategory(cat);
          }
        });
      });
  }

  AddSubCategory(cat: SubCategoryDTO) {
    this.subcategoryService.AddSubCategory(cat).subscribe(
      data => {
        if (data) {
          this.translateService.get('SavedSuccess').subscribe((res: string) => {
            this.toastService.add({
              severity: 'success',
              life: 3000,
              closable: true,
              summary: res
            });
            this.GetAllSubCategories();
          });
        }
      },
      error => {
        this.translateService.get('ErrorOccured').subscribe((res: string) => {
          this.toastService.add({
            severity: 'error',
            life: 3000,
            closable: true,
            summary: res
          });
          this.GetAllSubCategories();
        });
      }
    );
  }

  UpdateSubCategory(cat: SubCategoryDTO) {
    this.subcategoryService.UpdateSubCategory(cat).subscribe(
      data => {
        if (data) {
          this.translateService.get('SavedSuccess').subscribe((res: string) => {
            this.toastService.add({
              severity: 'success',
              life: 3000,
              closable: true,
              summary: res
            });
            this.GetAllSubCategories();
          });
        }
      },
      error => {
        this.translateService.get('ErrorOccured').subscribe((res: string) => {
          this.toastService.add({
            severity: 'error',
            life: 3000,
            closable: true,
            summary: res
          });
          this.GetAllSubCategories();
        });
      }
    );
  }

  GetCategoryName(categoryId: number) {
    if (this.allCategoriesLookup && this.allCategoriesLookup.length) {
      return this.allCategoriesLookup.filter(cat => cat.id === categoryId)[0];
    }
  }
}
