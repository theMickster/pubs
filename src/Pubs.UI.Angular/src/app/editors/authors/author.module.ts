import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { AuthorDetailComponent } from './author-detail/author-detail.component';
import { AuthorEditComponent } from './author-edit/author-edit.component';
import { AuthorListComponent } from './author-list.component';
import { AuthorResolver } from './author-resolver.service';

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: AuthorListComponent
      },
      {
        path: ':id',
        component: AuthorDetailComponent,
        resolve: {resolvedData : AuthorResolver}
      },
      {
        path: ':id/details',
        component: AuthorDetailComponent,
        resolve: {resolvedData : AuthorResolver}
      },
      {
        path: ':id/edit',
        component: AuthorEditComponent,
        resolve: {resolvedData : AuthorResolver}
      }
    ])
  ],
  declarations: [
    AuthorListComponent, 
    AuthorEditComponent,
    AuthorDetailComponent
  ],
})
export class AuthorModule { }
