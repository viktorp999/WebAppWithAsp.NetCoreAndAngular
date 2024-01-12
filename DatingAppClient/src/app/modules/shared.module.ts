import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TabsModule.forRoot(),
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
    BsDropdownModule.forRoot(),
    NgxGalleryModule,
  ],
  exports: [ToastrModule, BsDropdownModule, TabsModule, NgxGalleryModule],
})
export class SharedModule {}
