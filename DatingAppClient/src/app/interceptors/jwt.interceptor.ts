import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AccountService } from '../services/account.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private accountService: AccountService) {}

  intercept(
    req: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) {
          req = req.clone({
            setHeaders: {
              Authorization: `Bearer ${user.token}`,
            },
          });
        }
      },
    });

    return next.handle(req);
  }
}
