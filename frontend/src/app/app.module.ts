import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app.routes";
import { HttpClientModule } from "@angular/common/http";
import {FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { ConversionService } from "./service/conversion_service";
import { AppComponent } from "./app.component";
import { OnlineConversionComponent } from "./online-conversion/online-conversion.component";


@NgModule({
  declarations: [
    AppComponent,
    OnlineConversionComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
  ],
  providers: [
    ConversionService,
 
  ],

  bootstrap: [AppComponent],

})
export class AppModule { }
