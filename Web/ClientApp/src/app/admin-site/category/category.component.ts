import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CategoryService } from '../_services/category-services/category-service.service';
import { CategoryDTO } from 'src/app/_services/swagger/SwaggerClient.service';
import { ConfirmationService, Message } from 'primeng/api';

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
        }
      },
      error => {
        console.log(error);
      }
    );
  }

  confirmDelete() {
    this.confirmationService.confirm({
      message: 'Do you want to delete this record ?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.msgs = [
          { severity: 'info', summary: 'Confirmed', detail: 'Record deleted' }
        ];
      },
      reject: () => {
        this.msgs = [
          { severity: 'info', summary: 'Rejected', detail: 'You have rejected' }
        ];
      }
    });
  }
}
