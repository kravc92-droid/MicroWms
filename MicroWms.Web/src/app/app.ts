
import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Product, ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private productService = inject(ProductService);

  products = signal<Product[]>([]);
  loading = signal(true);
  error = signal('');

  showForm = signal(false);
  saving = signal(false);

  article = '';
  name = '';
  formError = '';

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe({
      next: (products) => {
        this.products.set(products);
        this.loading.set(false);
      },
      error: (err) => {
        console.error(err);
        this.error.set('Не удалось загрузить товары');
        this.loading.set(false);
      }
    });
  }

  addProduct(): void {
    this.formError = '';

    if (!this.article.trim() || !this.name.trim()) {
      this.formError = 'Заполните артикул и наименование';
      return;
    }

    this.saving.set(true);

    this.productService.createProduct({
      article: this.article.trim(),
      name: this.name.trim()
    }).subscribe({
      next: (product) => {
        this.products.update(products => [...products, product]);

        this.article = '';
        this.name = '';
        this.showForm.set(false);
        this.saving.set(false);
      },
      error: (err) => {
        console.error(err);
        this.formError = err.error?.errors
          ? 'Проверьте правильность заполнения полей'
          : 'Не удалось создать товар';

        this.saving.set(false);
      }
    });
  }
}
