import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { AppService } from './app.service';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'client';

  products?: Product[];
  selectedProduct: Product = { id: 0, name: '', price: 0 };
  isEditing: boolean = false;
  actualProduct: Product = { id: 0, name: '', price: 0 };

  constructor(private appService: AppService) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.appService.getProducts().subscribe(products => {
      this.products = products;
    });
  }

  addProduct(actualProduct: Product): void {
    this.appService.addProduct(this.actualProduct).subscribe(() => {
      this.getProducts(); 
      this.selectedProduct = { id: 0, name: '', price: 0 }; 
      this.actualProduct = { id: 0, name: '', price: 0 }; 
    });
  }

  editProduct(product: Product): void {
    this.selectedProduct = { ...product }; 
    this.isEditing = true;
  }

  updateProduct(): void {
    this.appService.updateProduct(this.selectedProduct).subscribe(() => {
      this.getProducts(); 
      this.selectedProduct = { id: 0, name: '', price: 0 };  
      this.isEditing = false;
    });
  }

  deleteProduct(id: number): void {
    this.appService.deleteProduct(id).subscribe(() => {
      this.getProducts(); 
    });
  }

  cancelEdit(): void {
    this.selectedProduct = { id: 0, name: '', price: 0 };
    this.isEditing = false;
  }
}
