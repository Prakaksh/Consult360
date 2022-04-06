import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientRoutingModule } from './patient-routing.module';
import { PatientDashboardComponent } from './patient-dashboard/patient-dashboard.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';





@NgModule({
  declarations: [
    PatientDashboardComponent, HeaderComponent, FooterComponent, HomeComponent, 
  ],
  imports: [
    CommonModule,PatientRoutingModule
  ]
})
export class PatientModule { }
