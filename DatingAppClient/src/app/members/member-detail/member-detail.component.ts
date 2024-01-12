import { Component, OnInit } from '@angular/core';
import { Member } from '../../models/member';
import { MembersService } from '../../services/members.service';
import { ActivatedRoute } from '@angular/router';
import {
  NgxGalleryAnimation,
  NgxGalleryImage,
  NgxGalleryOptions,
} from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrl: './member-detail.component.css',
})
export class MemberDetailComponent implements OnInit {
  member: Member | undefined;
  galleryOptions: NgxGalleryOptions[] = [];
  galleryImages: NgxGalleryImage[] = [];

  constructor(
    private memberService: MembersService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadMember();

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false,
      },
    ];
  }

  getImages() {
    if (!this.member) {
      return [];
    }
    const imgUrls = [];
    for (const photo of this.member.photos) {
      imgUrls.push({
        small: photo.url,
        medium: photo.url,
        big: photo.url,
      });
    }
    return imgUrls;
  }

  loadMember() {
    const username = this.route.snapshot.paramMap.get('username');
    if (!username) {
      return;
    }
    this.memberService.getMemeber(username).subscribe({
      next: (member) => {
        this.member = member;
        this.galleryImages = this.getImages();
      },
    });
  }
}
