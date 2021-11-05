import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { AuthorsService } from 'src/app/data-access/authors.service';
import { IAuthorResolved } from 'src/app/data-structures/interfaces/IAuthorResolved';

@Injectable({
    providedIn: 'root'
  })

 ///******************************************************************************************
 /// Intermedite Author Resolver to run prior to the author component from being loaded. 
 /// Aids in pre-fetching data prior to loading a component.
 /// ******************************************************************************************
export class AuthorResolver implements Resolve<IAuthorResolved> {

    constructor(private authorsService: AuthorsService) { }

    resolve(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<IAuthorResolved> {
        const id = route.paramMap.get('id');
        if (isNaN(+id)) {
          const message = `Author id was not a number: ${id}`;
          console.error(message);
          return of({ author: null, error: message });
        }
    
        return this.authorsService.getAuthor(+id)
          .pipe(
            map(author => ({ author })),
            catchError(error => {
              const message = `Retrieval error: ${error}`;
              console.error(message);
              return of({ author: null, error: message });
            })
          );
      }
}