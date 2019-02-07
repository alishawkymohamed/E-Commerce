import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/api';
import { CategoryDTO } from 'src/app/_services/swagger/SwaggerClient.service';

@Component({
  selector: 'app-add-edit-category',
  templateUrl: './add-edit-category.component.html',
  styleUrls: ['./add-edit-category.component.scss']
})
export class AddEditCategoryComponent implements OnInit {
  category: CategoryDTO;
  submitted = false;

  constructor(
    private ref: DynamicDialogRef,
    private config: DynamicDialogConfig
  ) {
    this.category =
      this.config.data != null ? this.config.data : new CategoryDTO();
  }

  ngOnInit() {}

  onSubmit() {
    this.submitted = true;
    this.ref.close(this.category);
  }
}
