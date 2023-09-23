import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CoreModule } from "./core/core.module";
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { FormsModule,ReactiveFormsModule }   from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PersonalTestModule } from './personalTest/personal-test.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, "assets/i18n/", ".json");
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    CoreModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    PersonalTestModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule
  ],
  exports:[
    CoreModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    MatFormFieldModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
