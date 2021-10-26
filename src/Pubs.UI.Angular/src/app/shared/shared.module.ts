import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
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
    YesNoPipe
  ]
})
export class SharedModule { }
