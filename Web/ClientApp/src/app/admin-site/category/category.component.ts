import { AddEditCategoryComponent } from './add-edit-category/add-edit-category.component';
import {
  Component,
  OnInit,
  ViewEncapsulation,
  ChangeDetectionStrategy
} from '@angular/core';
import { CategoryService } from '../_services/category-services/category-service.service';
import { CategoryDTO } from 'src/app/_services/swagger/SwaggerClient.service';
import {
  ConfirmationService,
  Message,
  MessageService,
  DialogService
} from 'primeng/api';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class CategoryComponent implements OnInit {
  allCategories: CategoryDTO[];
  msgs: Message[] = [];
  constructor(
    private categoryService: CategoryService,
    private translateService: TranslateService,
    private toastService: MessageService,
    public dialogService: DialogService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.GetAllCategories();
  }

  GetAllCategories() {
    this.categoryService.GetAllCategories().subscribe(data => {
      if (data) {
        this.allCategories = data.data;
      }
    });
  }

  DeleteCategory(Id: number) {
    this.categoryService.DeleteCategory(Id).subscribe(
      data => {
        if (data && data.length) {
          this.GetAllCategories();
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

  confirmDelete(categoryId: number) {
    this.confirmationService.confirm({
      message: null,
      header: null,
      icon: 'pi pi-info-circle',
      accept: () => {
        this.DeleteCategory(categoryId);
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

  showAddEditComponent(category: CategoryDTO) {
    this.translateService
      .get(['Create', 'Update', 'Category'])
      .subscribe((res: any) => {
        const ref = this.dialogService.open(AddEditCategoryComponent, {
          header:
            category != null
              ? `${res['Update']} ${res['Category']}`
              : `${res['Create']} ${res['Category']}`,
          data: Object.assign({}, category)
        });

        ref.onClose.subscribe((cat: CategoryDTO) => {
          if (!cat.categoryId) {
            this.AddCategory(cat);
          } else {
            this.UpdateCategory(cat);
          }
        });
      });
  }

  AddCategory(cat: CategoryDTO) {
    this.categoryService.AddCategory(cat).subscribe(
      data => {
        if (data) {
          this.translateService.get('SavedSuccess').subscribe((res: string) => {
            this.toastService.add({
              severity: 'success',
              life: 3000,
              closable: true,
              summary: res
            });
            this.GetAllCategories();
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
          this.GetAllCategories();
        });
      }
    );
  }

  UpdateCategory(cat: CategoryDTO) {
    this.categoryService.UpdateCategory(cat).subscribe(
      data => {
        if (data) {
          this.translateService.get('SavedSuccess').subscribe((res: string) => {
            this.toastService.add({
              severity: 'success',
              life: 3000,
              closable: true,
              summary: res
            });
            this.GetAllCategories();
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
          this.GetAllCategories();
        });
      }
    );
  }
}
