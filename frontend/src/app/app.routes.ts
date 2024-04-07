import { NgModule } from '@angular/core';
import {PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { OnlineConversionComponent } from './online-conversion/online-conversion.component';

const routes: Routes = [
  {path: '',  component : OnlineConversionComponent},
];


@NgModule({
  imports: [RouterModule.forRoot(routes, {preloadingStrategy: PreloadAllModules})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
