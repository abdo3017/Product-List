import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../interfaces/product';

@Injectable()
export class ProductService {
    apiUrl: any;

    constructor(private http: HttpClient) {
        this.apiUrl = 'https://localhost:44367/'
    }

    getAll(): Observable<Product[]> {
        return this.http.get<Product[]>(`${this.apiUrl}Products`);
    }

    getById(id: number): Observable<Product> {
        return this.http.get<Product>(`${this.apiUrl}Products/GetById?id=${id}`);
    }

    add(product: Product): Observable<Product> {
        return this.http.post<Product>(`${this.apiUrl}Products`, product);
    }

    delete(id: number): Observable<Product> {
        return this.http.delete<Product>(`${this.apiUrl}Products?id=${id}`);
    }

    update(product: Product): Observable<Product> {
        return this.http.put<Product>(`${this.apiUrl}Products?id=${product.id}`, product);
    }
}
