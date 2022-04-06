import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./components/home/home.component";
import { PatientDashboardComponent } from "./patient-dashboard/patient-dashboard.component";


const routes: Routes = [
  {
    path: '',
    component: PatientDashboardComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: '', redirectTo: '/patient/home', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PatientRoutingModule { }
