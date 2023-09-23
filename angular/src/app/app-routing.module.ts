import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonalTestComponent } from './personalTest/personal-test.component';

const routes: Routes = [
  {
    path: 'person',
    pathMatch: 'full',
    component: PersonalTestComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
