import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map, retry } from 'rxjs/operators';
import { AuthorViewDto } from '../data-structures/models/Dtos/AuthorViewDto';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  private authorsUrl : string = "authors";
  private theApiUrl = environment.apiBaseUrl + '/authors'

  constructor(private http: HttpClient) { 

  }

  public getAuthors() : Observable<AuthorViewDto[]>{
    return this.http.get<AuthorViewDto[]>(
      this.theApiUrl
    )
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
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
}
