import { CommonModule } from '@angular/common'; 
import { BrowserModule } from '@angular/platform-browser';
 
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { UploadComponent } from './components/upload/upload.component';
import { UploadService } from './components/upload/services/upload.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UploadComponent
  ],
  imports: [
    NgbModule.forRoot(),
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: UploadComponent, pathMatch: 'full' },
      { path: 'upload', component: UploadComponent }
    ])
  ],
  providers: [UploadService],
  bootstrap: [AppComponent]
})
export class AppModule { }
