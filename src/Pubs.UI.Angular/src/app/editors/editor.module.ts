import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../auth/auth.guard';
import { SharedModule } from '../shared/shared.module';
import { EditorComponent } from './home/editor.component';

const routes : Routes = [
  {
    path: '',
    component: EditorComponent
  },
{
  path: 'authors',
  canLoad: [AuthGuard],
  data: { preload: true},
  loadChildren : () =>        
    import('../editors/authors/author.module')
      .then(m => m.AuthorModule)        
}
// ,  
// {
//   path: 'editors/publishers',
//   canLoad: [AuthGuard],
//   data: { preload: true},
//   loadChildren : () =>        
//     import('editors/publishers/publisher.module')
//       .then(m => m.PublisherModule)        
// }, 
// {
//   path: 'editors/titles',
//   canLoad: [AuthGuard],
//   data: { preload: true},
//   loadChildren : () =>        
//     import('editors/titles/title.module')
//       .then(m => m.TitleModule)        
// }
]

@NgModule({
  declarations: [
    EditorComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class EditorModule { }
