import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { TitleListComponent } from './title-list.component';

@NgModule({  
  imports: [
    SharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: TitleListComponent
      }
    ])
  ],
  declarations: [
    TitleListComponent
  ]
})
export class TitleModule { }
