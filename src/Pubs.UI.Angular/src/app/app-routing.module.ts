import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/home/admin.component';
import { AppComponent } from './app.component';
import { AuthGuard } from './auth/auth.guard';
import { EditorComponent } from './editors/home/editor.component';

import { HomeComponent } from './home/home.component';
import { WelcomeComponent } from './home/welcome.component';
import { HumanResourcesComponent } from './human-resources/home/human-resources.component';
import { PageNotFoundComponent } from './oops/page-not-found.component';
import { ReportsComponent } from './reports/home/reports.component';
import { SalesComponent } from './sales/home/sales.component';

const routes: Routes = [
  { 
    path: 'welcome', component: WelcomeComponent 
  },
  { 
    path: 'home', 
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: HomeComponent 
  },
  {
    path: 'admin',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: AdminComponent    
  },
  {
    path: 'editors',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: EditorComponent    
  },
  {
    path: 'editors/authors',
    canLoad: [AuthGuard],
    data: { preload: true},
    loadChildren : () =>        
      import('./editors/authors/author.module')
        .then(m => m.AuthorModule)        
  },  
  {
    path: 'editors/publishers',
    canLoad: [AuthGuard],
    data: { preload: true},
    loadChildren : () =>        
      import('./editors/publishers/publisher.module')
        .then(m => m.PublisherModule)        
  }, 
  {
    path: 'editors/titles',
    canLoad: [AuthGuard],
    data: { preload: true},
    loadChildren : () =>        
      import('./editors/titles/title.module')
        .then(m => m.TitleModule)        
  },
  {
    path: 'sales',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: SalesComponent    
  },
  {
    path: 'reports',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: ReportsComponent    
  },
  {
    path: 'hr',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: HumanResourcesComponent    
  },
  {
    path: '', redirectTo: 'home', pathMatch:'full'
  },
  { 
    path: '**', 
    component: PageNotFoundComponent 
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
