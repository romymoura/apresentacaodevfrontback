import { DetailsComponent } from './airplane/details/details.component';
import { AuthService } from './auth/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { CarouselComponent } from './carousel/carousel.component';
import { ScrollspyComponent } from './scrollspy/scrollspy.component';
import { AirplaneComponent } from './airplane/airplane.component';
import { CreateComponent } from './airplane/create/create.component';
import { DeleteComponent } from './airplane/delete/delete.component';
import { ListComponent } from './airplane/list/list.component';
import { AirplaneService } from './airplane.service';
import { HomeComponent } from './home/home.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CarouselComponent,
    ScrollspyComponent,
    AirplaneComponent,
    DetailsComponent,
    CreateComponent,
    DeleteComponent,
    ListComponent,
    HomeComponent,
    SignInComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AirplaneService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
