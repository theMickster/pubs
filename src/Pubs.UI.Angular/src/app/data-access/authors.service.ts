import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map, retry } from 'rxjs/operators';
import { Author } from '../data-structures/models/Author';
import { AuthorViewModel } from '../data-structures/viewModels/authorViewModel';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  private authorsUrl: string = "authors";
  private authorsBaseUrl = environment.apiBaseUrl + this.authorsUrl;

  constructor(private http: HttpClient) {

  }

  authors$ = this.http.get<AuthorViewModel[]>(this.authorsBaseUrl).pipe(
    tap((data) => console.log('AuthorViewModel: ', JSON.stringify(data))),    
    catchError(this.handleError)
  )

  getAuthor(id: number): Observable<Author> {
    if (id === 0) {
      return of(this.initializeAuthor());
    }

    const url = `${this.authorsBaseUrl}/${id}`;

    return this.http.get<Author>(url)
      .pipe(
        // tap(data => console.log('getAuthor: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  updateAuthor(author: Author): Observable<Author> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    const url = `${this.authorsBaseUrl}/${author.id}`;

    return this.http.put<Author>(url, author, { headers })
      .pipe(
        tap(() => console.log('updateAuthor: ' + JSON.stringify(author))),
        // Return the product on an update
        map(() => author),
        catchError(this.handleError)
      );
  }

  private handleError(err: any): Observable<never> {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }

  private initializeAuthor(): Author {
    // Return an initialized object
    return {
      id: 0,
      authorCode: null,
      firstName: null,
      lastName: null,
      phoneNumber: null,
      address: null,
      city: null,
      state: null,
      zipCode: null,
      contract: false
    };
  }
}
