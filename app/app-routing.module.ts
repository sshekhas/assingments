import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormComponent } from "./form/form.component";
import { ListComponent } from "./list/list.component";


const routes: Routes = [
  {path:'addtolist', component:FormComponent},
  {path:'showlist', component:ListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
