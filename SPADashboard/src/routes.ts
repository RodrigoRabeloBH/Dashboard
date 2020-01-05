import { Routes } from '@angular/router';
import { SectionSalesComponent } from './app/sections/section-sales/section-sales.component';
import { SectionHealthComponent } from './app/sections/section-health/section-health.component';
import { SectionOrdesComponent } from './app/sections/section-ordes/section-ordes.component';


export const appRoutes : Routes = [
    {path: 'sales', component: SectionSalesComponent},
    {path: 'health', component: SectionHealthComponent},   
    {path:'orders' , component: SectionOrdesComponent },   
    {path: '', redirectTo: '/sales', pathMatch: 'full'}       
    
]

