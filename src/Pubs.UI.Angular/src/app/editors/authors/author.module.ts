import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { AuthorDetailComponent } from './author-detail/author-detail.component';
import { AuthorEditComponent } from './author-edit/author-edit.component';
import { AuthorListComponent } from './author-list.component';

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
        component: AuthorDetailComponent
      },
      {
        path: ':id/details',
        component: AuthorDetailComponent
      },
      {
        path: ':id/edit',
        component: AuthorEditComponent
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
