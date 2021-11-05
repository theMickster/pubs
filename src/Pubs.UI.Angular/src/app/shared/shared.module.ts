import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { YesNoPipe } from './yes-no.pipe';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [  
    YesNoPipe
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    YesNoPipe
  ]
})
export class SharedModule { }
