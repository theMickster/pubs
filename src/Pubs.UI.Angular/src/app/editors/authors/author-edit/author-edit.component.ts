import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IAuthorResolved } from 'src/app/data-structures/interfaces/IAuthorResolved';
import { Author } from 'src/app/data-structures/models/Author';

@Component({
  selector: 'app-author-edit',
  templateUrl: './author-edit.component.html',
  styleUrls: ['./author-edit.component.css']
})
export class AuthorEditComponent implements OnInit {
  pageTitle = 'Author Edit';

  author: Author;
  errorMessage: string;

  private dataIsValid: { [key: string]: boolean } = {};

  constructor(
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    const resolvedData: IAuthorResolved = this.route.snapshot.data['resolvedData'];
    this.errorMessage = resolvedData.error;
    this.onAuthorRetrieved(resolvedData.author);
  }

  onAuthorRetrieved(author: Author): void {
    this.author = author;

    if (this.author) {
      this.pageTitle = `Author Detail: ${this.author.firstName} ${this.author.lastName}`;
    } else {
      this.pageTitle = 'No author found';
    }
  }

  submitted = false;



  saveAuthor(): void {
    this.submitted = true;
    // if (this.isValid()) {
    //   if (this.product.id === 0) {
    //     this.productService.createProduct(this.product).subscribe({
    //       next: () => this.onSaveComplete(`The new ${this.product.productName} was saved`),
    //       error: err => this.errorMessage = err
    //     });
    //   } else {
    //     this.productService.updateProduct(this.product).subscribe({
    //       next: () => this.onSaveComplete(`The updated ${this.product.productName} was saved`),
    //       error: err => this.errorMessage = err
    //     });
    //   }
    // } else {
    //   this.errorMessage = 'Please correct the validation errors.';
    // }

  }

  isValid(path?: string): boolean {
    this.validate();
    if (path) {
      return this.dataIsValid[path];
    }
    return (this.dataIsValid &&
      Object.keys(this.dataIsValid).every(d => this.dataIsValid[d] === true));
  }

  validate(): void {

  }
}
