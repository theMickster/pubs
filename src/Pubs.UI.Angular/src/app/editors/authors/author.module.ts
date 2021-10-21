import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { AuthorListComponent } from './author-list.component';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  imports: [
    MatTableModule,
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
