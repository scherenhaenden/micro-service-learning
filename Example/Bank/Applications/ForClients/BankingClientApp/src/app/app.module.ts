import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TemplateViewIndexComponent } from './views/template-view-index/template-view-index.component';
import { TemplateViewProfileComponent } from './views/template-view-profile/template-view-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    TemplateViewIndexComponent,
    TemplateViewProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
