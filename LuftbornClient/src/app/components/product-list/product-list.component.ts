import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/productservice';
import { Product } from '../../interfaces/product';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ProductComponent } from '../product/product.component';
import { Action } from 'src/app/enums/action.enum';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
  providers: [DialogService]
})
export class ProductListComponent implements OnInit {

  products: Product[] = [];
  ref: DynamicDialogRef | undefined;
  constructor(private productService: ProductService, private dialogService: DialogService) { }

  ngOnInit() {
    this.getProductsData();
  }

  getProductsData() {
    this.productService.getAll().subscribe((data) => {
      this.products = data;
    });
  }

  onUpdate(product: Product) {
    this.showDialog(Action.UPDATE, product);

  }
  onDelete(id: number) {
    this.productService.delete(id).subscribe(s => {
      this.getProductsData();
    });
  }

  onAdd() {
    this.showDialog(Action.ADD);
  }

  showDialog(action: string, product?: Product) {
    this.ref = this.dialogService.open(ProductComponent,
      {
        width: "33%",
        data: {
          product,
          action
        },
        header: `${action} a Product`
      });
    this.ref.onClose.subscribe((refresh: boolean) => {
      this.getProductsData();
    });
  }
}

