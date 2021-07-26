import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonasComponent } from './components/personas/personas.component';
import { PersonaComponent } from './components/personas/persona/persona.component';
import { ListPersonasComponent } from './components/personas/list-personas/list-personas.component';
import { EpsComponent } from './components/eps/eps.component';
import { ListEpsComponent } from './components/eps/list-eps/list-eps.component';
import { FooterComponent } from './components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonasComponent,
    PersonaComponent,
    ListPersonasComponent,
    EpsComponent,
    ListEpsComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({timeOut:10000, positionClass: 'toast-top-right', preventDuplicates:true})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
