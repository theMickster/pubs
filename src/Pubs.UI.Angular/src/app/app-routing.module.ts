import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './auth/auth.guard';

import { HomeComponent } from './home/home.component';
import { WelcomeComponent } from './home/welcome.component';
import { PageNotFoundComponent } from './oops/page-not-found.component';

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
