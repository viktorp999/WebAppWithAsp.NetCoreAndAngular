import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Member } from '../models/member';
import { Observable } from 'rxjs';
import { MembersService } from '../services/members.service';

@Injectable({
  providedIn: 'root',
})
export class MemberDetailedResolver implements Resolve<Member> {
  constructor(private memberService: MembersService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Member> {
    return this.memberService.getMemeber(route.paramMap.get('username')!);
  }
}
