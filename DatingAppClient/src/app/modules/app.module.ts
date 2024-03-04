import { NgModule } from '@angular/core';
import { AppComponent } from '../app.component';
import { NavComponent } from '../nav/nav.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { MemberCardComponent } from '../members/member-card/member-card.component';
import { JwtInterceptor } from '../interceptors/jwt.interceptor';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';
import { LoadingInterceptor } from '../interceptors/loading.interceptor';
import { TextInputComponent } from '../forms/text-input/text-input.component';
import { DatePickerComponent } from '../forms/date-picker/date-picker.component';
import { MemberMessagesComponent } from '../members/member-messages/member-messages.component';

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
    MemberCardComponent,
    MemberEditComponent,
    TextInputComponent,
    DatePickerComponent,
    MemberMessagesComponent,
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    ReactiveFormsModule,
  ],

  providers: [
    AccountService,
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
