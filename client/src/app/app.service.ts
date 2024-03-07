import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  baseUrl = 'https://localhost:7296/api/';
  constructor(private http: HttpClient) { }

  
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl+'products');
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}products/${id}`);
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(`${this.baseUrl}products`, product);
  }

  updateProduct(product: Product): Observable<any> {
    return this.http.put<Product>(`${this.baseUrl}products`, product);
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}products/${id}`);
  }
}
