import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { HumanResourcesComponent } from './home/human-resources.component';

@NgModule({
  declarations: [
    HumanResourcesComponent
  ],
  imports: [
    SharedModule
  ]
})
export class HumanResourcesModule { }
