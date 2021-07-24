import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { EmailTemplatesListComponent } from './components/email-templates-list/email-templates-list.component';
import { DetailRowService, FilterService, GridAllModule, GridModule, GroupService, PageService, SearchService, SortService, ToolbarService } from '@syncfusion/ej2-angular-grids';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TabModule } from '@syncfusion/ej2-angular-navigations';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EmailTemplatesListComponent
  ],
  imports: [
    BrowserAnimationsModule,
    GridModule,
    GridAllModule,
    TabModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [
    PageService,
    SortService,
    FilterService,
    GroupService,
    DetailRowService,
    SearchService,
    ToolbarService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
