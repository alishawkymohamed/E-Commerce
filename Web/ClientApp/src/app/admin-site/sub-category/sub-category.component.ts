import { Component, OnInit } from '@angular/core';
import { SubCategoryDTO } from 'src/app/_services/swagger/SwaggerClient.service';
import { TranslateService } from '@ngx-translate/core';
import {
  MessageService,
  DialogService,
  ConfirmationService
} from 'primeng/api';
import { SubCategoryService } from '../_services/sub-category-services/sub-category-service.service';
import { AddEditSubCategoryComponent } from './add-edit-sub-category/add-edit-sub-category.component';

@Component({
  selector: 'app-sub-category',
  templateUrl: './sub-category.component.html',
  styleUrls: ['./sub-category.component.scss']
})
export class SubCategoryComponent implements OnInit {
  allSubCategories: SubCategoryDTO[];
  constructor(
    private subcategoryService: SubCategoryService,
    private translateService: TranslateService,
    private toastService: MessageService,
    public dialogService: DialogService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.GetAllSubCategories();
  }

  GetAllSubCategories() {
    this.subcategoryService.GetAllSubCategories().subscribe(data => {
      if (data) {
        this.allSubCategories = data.data;
      }
    });
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

  showAddEditComponent(category: SubCategoryDTO) {
    this.translateService
      .get(['Create', 'Update', 'Category'])
      .subscribe((res: any) => {
        const ref = this.dialogService.open(AddEditSubCategoryComponent, {
          header:
            category != null
              ? `${res['Update']} ${res['Category']}`
              : `${res['Create']} ${res['Category']}`,
          data: Object.assign({}, category)
        });

        ref.onClose.subscribe((cat: SubCategoryDTO) => {
          if (!cat.subCategoryId) {
            this.AddSubCategory(cat);
          } else {
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
}
