import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { AdminComponent } from './home/admin.component';

@NgModule({
  declarations: [
    AdminComponent
  ],
  imports: [
    SharedModule
  ]
})
export class AdminModule { }
