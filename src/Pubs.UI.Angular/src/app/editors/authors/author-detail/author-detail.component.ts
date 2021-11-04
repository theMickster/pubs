import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IAuthorResolved } from 'src/app/data-structures/interfaces/IAuthorResolved';
import { Author } from 'src/app/data-structures/models/Author';

@Component({
  selector: 'app-author-detail',
  templateUrl: './author-detail.component.html',
  styleUrls: ['./author-detail.component.css']
})
export class AuthorDetailComponent implements OnInit {

  pageTitle = 'Author Detail';

  author: Author;
  errorMessage: string;

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
      this.pageTitle = `Author Edit: ${this.author.firstName} ${this.author.lastName}`;
    } else {
      this.pageTitle = 'No author found';
    }
  }

}
