import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EMAIL_TEMPLATES_GETALL_URL, EMAIL_TEMPLATES_GET_URL } from '../constants/endpoints';
import { EmailTemplates } from '../models/email-templates';

@Injectable({
  providedIn: 'root'
})
export class EmailTemplatesService {

  constructor(private http: HttpClient) {

  }

  getAll(): Observable<EmailTemplates[]> {
    return this.http.get<any>(`${environment.apiUrl}${EMAIL_TEMPLATES_GETALL_URL}`);
  }

  getPaged(skip : number = 0, take : number = 0, searchKeyword: string = '', orderBy: string = '', sortOrder: string = ''): Observable<EmailTemplates[]> {
    return this.http.get<any>(`${environment.apiUrl}${EMAIL_TEMPLATES_GETALL_URL}?skip=${skip}&take=${take}&searchKeyword=${searchKeyword}&orderBy=${orderBy}&sortOrder=${sortOrder}`);
  }

  get(id: string): Observable<EmailTemplates> {
    return this.http.get<any>(`${environment.apiUrl}${EMAIL_TEMPLATES_GET_URL}/${id}`);
  }
}
