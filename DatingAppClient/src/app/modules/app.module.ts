import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from '../app.component';
import { NavComponent } from '../nav/nav.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
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
import { ToastrModule } from 'ngx-toastr';

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
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
  ],

  providers: [AccountService],
  bootstrap: [AppComponent],
})
export class AppModule {}
