import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { AuthorListComponent } from './author-list.component';

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: AuthorListComponent
      }
    ])
  ],
  declarations: [
    AuthorListComponent
  ],
})
export class AuthorModule { }
