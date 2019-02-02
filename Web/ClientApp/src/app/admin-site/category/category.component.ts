import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CategoryService } from '../_services/category-services/category-service.service';
import { CategoryDTO } from 'src/app/_services/swagger/SwaggerClient.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: [ './category.component.scss' ],
  encapsulation: ViewEncapsulation.None
})
export class CategoryComponent implements OnInit {
  allCategories: CategoryDTO[];
  constructor (private categoryService: CategoryService) { }

  ngOnInit() {
    this.categoryService.GetAllCategories().subscribe(data => {
      if (data) {
        this.allCategories = data.data;
        console.log(this.allCategories);
      }
    });
  }

}
