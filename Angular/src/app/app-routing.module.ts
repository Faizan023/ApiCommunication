import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './listcomponent/list.component';
import { logincomponent } from './logincomponent/login.component';

const routes: Routes = [
  { path: 'list', component: ListComponent },
  { path: 'login', component: logincomponent },
  { path: '', component: logincomponent, pathMatch: 'full' },
  { path: '**', component: logincomponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
