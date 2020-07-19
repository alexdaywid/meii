import { ComprasModule } from './pages/compras/compras.module';
import { VendasModule } from './pages/vendas/vendas.module';
import { SharedModule } from './shared/shared.module';
import { ProdutosModule } from './pages/produtos/produtos.module';
import { ClienteRoutingModule } from './pages/cliente/cliente-routing-module';
import { ClienteModule } from './pages/cliente/cliente.module';
import { SlideMenuModule } from 'primeng/slidemenu';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuNavbarComponent } from './shared/layout/menu-navbar/menu-navbar.component';
import { FooterComponent } from './shared/layout/footer/footer.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AccordionModule} from 'primeng/accordion';
import {PanelMenuModule} from 'primeng/panelmenu';
import { HttpClientModule } from '@angular/common/http';
import { DashboardModule } from './pages/dashboard/dashboard.module';
import { DlDateTimeDateModule, DlDateTimePickerModule } from 'angular-bootstrap-datetimepicker';
import { MenuListComponent } from './shared/components/menu-list/menu-list.component';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    AppComponent,
    MenuNavbarComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    AccordionModule,
    TieredMenuModule,
    SlideMenuModule,
    PanelMenuModule,
    ClienteModule,
    ProdutosModule,
    DashboardModule,
    VendasModule,
    ComprasModule,
    HttpClientModule,
    DlDateTimeDateModule,
    DlDateTimePickerModule,
    SharedModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-top-full-width',
      preventDuplicates: true,
    }),
  ],
  providers: [{
    provide: LOCALE_ID,
    useValue: 'pt-BR'
  }],
  bootstrap: [AppComponent],
})
export class AppModule { }
