import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { SharedRoutingModule } from './shared-routing.module';
import { NavBarWebisteComponent } from './nav-bar-webiste/nav-bar-webiste.component';
import { MenubarModule } from 'primeng/menubar';
import { ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { CardModule } from 'primeng/card';
import { CheckboxModule } from 'primeng/checkbox';
import { FloatLabelModule } from 'primeng/floatlabel';
@NgModule({
  declarations: [NavBarWebisteComponent],
  imports: [
    CommonModule,
    SharedRoutingModule,
    ButtonModule,
    MenubarModule,
    InputTextModule,
    CardModule,
    FloatLabelModule,
  ],
  exports: [
    ButtonModule,
    CommonModule,
    MenubarModule,
    NavBarWebisteComponent,
    InputTextModule,
    CardModule,
    FloatLabelModule,
    CheckboxModule,
  ],
})
export class SharedModule {}
