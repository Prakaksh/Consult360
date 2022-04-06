import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorRoutingModule } from './doctor-routing.module';
import { DoctorDashboardComponent } from './doctor-dashboard/doctor-dashboard.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';



@NgModule({
  declarations: [
    DoctorDashboardComponent, HeaderComponent, FooterComponent, HomeComponent,
  ],
  imports: [
    CommonModule, DoctorRoutingModule
  ]
})
export class DoctorModule { }
