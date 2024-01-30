import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TabsModule.forRoot(),
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
    BsDropdownModule.forRoot(),
    NgxGalleryModule,
    NgxSpinnerModule.forRoot({ type: 'line-scale-party' }),
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
  ],
  exports: [
    ToastrModule,
    BsDropdownModule,
    TabsModule,
    NgxGalleryModule,
    NgxSpinnerModule,
    BsDatepickerModule,
    PaginationModule,
  ],
})
export class SharedModule {}
