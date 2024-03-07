import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbCollapseModule, NgbNavModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// scroll package
import { ScrollToModule } from '@nicky-lenaers/ngx-scroll-to';

// component
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SignmodalComponent } from './signmodal/signmodal.component';
import { LanguageService } from '../services/language.service';
import { TranslateModule } from '@ngx-translate/core';
import { AcountSidemenuComponent } from './acount-sidemenu/acount-sidemenu.component';
import { AccountBreadcrumbsComponent } from './account-breadcrumbs/account-breadcrumbs.component';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    SignmodalComponent,
    AccountBreadcrumbsComponent,
    AcountSidemenuComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgbCollapseModule,
    NgbNavModule,
    NgbDropdownModule,
    FormsModule,
    TranslateModule,
    ReactiveFormsModule,
    ScrollToModule.forRoot()
  ],
  providers: [LanguageService],
  exports: [
    HeaderComponent,
    FooterComponent,
    AcountSidemenuComponent,
    AccountBreadcrumbsComponent
  ]
})
export class SharedModule { }
