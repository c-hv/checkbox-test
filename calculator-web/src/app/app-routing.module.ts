import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalculatorComponent } from './components/calculator.component';

const routes: Routes = [
  { path: 'calculator', component: CalculatorComponent},
  { path: '', redirectTo: 'calculator', pathMatch: 'full' },
  { path: '**', redirectTo: 'calculator' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
