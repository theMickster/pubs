import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthorsService } from 'src/app/data-access/authors.service';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent {
  pageTitle = 'Author List';
  errorMessage = '';
  columnsToDisplay: string[] = ['authorId', 'authorCode', 'name', 'phoneNumber', 'contract'];

  constructor(
    private authorsService: AuthorsService,
    private route: ActivatedRoute) { }

  authors$ = this.authorsService.authors$.pipe(
    catchError(err => {
      this.errorMessage = err;
      return EMPTY;
    })
  )

}
