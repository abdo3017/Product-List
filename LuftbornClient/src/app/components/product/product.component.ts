import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Action } from 'src/app/enums/action.enum';
import { Product } from 'src/app/interfaces/product';
import { ProductService } from 'src/app/services/productservice';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {
  @ViewChild("form") forGroup: FormGroup;
  product: Product = {
    availableAmount: null,
    id: null,
    cost: null,
    name: null
  };
  refresh: boolean;
  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private productService: ProductService) { }

  ngOnInit() {
    if (this.config.data.action == Action.UPDATE) {
      this.product = this.config.data.product;
    }
  }
  closeDialog() {
    if (this.forGroup.valid) {
      switch (this.config.data.action) {
        case "Update":
          this.productService.update(this.product).subscribe(res => {
            this.ref.close(true);
          })
          break;
        case "Add":
          this.productService.add(this.product).subscribe(res => {
            this.ref.close(true);
          })
          break;
        default:
      }
    }
  }

}
