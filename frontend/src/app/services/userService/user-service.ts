import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { userModel } from '../../models/user';
import { Observable } from 'rxjs';
import { HttpService } from '../httpService/http-service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
    http : HttpService = inject(HttpService);
    url : string = this.http.url + "auth";
}