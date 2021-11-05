import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { PublisherListComponent } from './publisher-list.component';

@NgModule({  
  imports: [
    SharedModule,
    RouterModule.forChild([
      {
        path: '',
        component: PublisherListComponent
      }
    ])
  ],
  declarations: [
    PublisherListComponent
  ]
})
export class PublisherModule { }
