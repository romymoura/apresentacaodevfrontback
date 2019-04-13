import { DetailsComponent } from './airplane/details/details.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AirplaneComponent } from './airplane/airplane.component';
import { CreateComponent } from './airplane/create/create.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { DeleteComponent } from './airplane/delete/delete.component';



const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: 'airplanes', component: AirplaneComponent},
  {path: 'airplanes/new', component: CreateComponent },
  {path: 'airplanes/details/:id', component: DetailsComponent },
  {path: 'airplanes/delete/:id', component: DeleteComponent },
  {path: 'sign-in', component: SignInComponent},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
