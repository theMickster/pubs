import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { EditorComponent } from './home/editor.component';

@NgModule({
  declarations: [
    EditorComponent
  ],
  imports: [
    SharedModule,
    RouterModule
  ]
})
export class EditorModule { }
