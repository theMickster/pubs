import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthorsService } from 'src/app/data-access/authors.service';
import { AuthorViewDto } from 'src/app/data-structures/models/Dtos/AuthorViewDto';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent implements OnInit {
  pageTitle = 'Author List';
  errorMessage = '';
  filteredAuthors: AuthorViewDto[] = [];
  authors: AuthorViewDto[] = [];
  columnsToDisplay: string[] = ['authorId', 'authorCode', 'name', 'phoneNumber', 'contract'];

  constructor(
    private authorsService: AuthorsService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.authorsService.getAuthors().subscribe({
      next: aa => {
        this.authors = aa;
        // this.filteredAuthors = this.performFilter(this.listFilter);
      },
      error: err => this.errorMessage = err
    });

  }

}
