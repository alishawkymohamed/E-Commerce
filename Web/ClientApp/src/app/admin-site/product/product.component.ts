import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Lookup } from 'src/app/_services/swagger/SwaggerClient.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  allCategoriesLookup: Lookup[];

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit() {
    this.GetAllCategoriesLookup();
  }

  GetAllCategoriesLookup() {
    this.allCategoriesLookup = this.route.snapshot.data.CategoryLookup;
  }

  gotoAddEditComponent() {
    this.router.navigate(['admin', 'product', 'add']);
  }
}
