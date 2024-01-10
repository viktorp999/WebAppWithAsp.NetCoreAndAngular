import { NgModule } from '@angular/core';
import { AppComponent } from '../app.component';
import { NavComponent } from '../nav/nav.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AccountService } from '../services/account.service';
import { BrowserModule } from '@angular/platform-browser';
import { HomeComponent } from '../home/home.component';
import { RegisterComponent } from '../register/register.component';
import { MemberListComponent } from '../members/member-list/member-list.component';
import { MemberDetailComponent } from '../members/member-detail/member-detail.component';
import { MessagesComponent } from '../messages/messages.component';
import { ListsComponent } from '../lists/lists.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared.module';
import { ErrorInterceptor } from '../interceptors/error.interceptor';
import { TestErrorComponent } from '../errors/test-error/test-error.component';
import { NotFoundComponent } from '../errors/not-found/not-found.component';
import { ServerErrorComponent } from '../errors/server-error/server-error.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MemberListComponent,
    MemberDetailComponent,
    MessagesComponent,
    ListsComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    SharedModule,
  ],

  providers: [
    AccountService,
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
