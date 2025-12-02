import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { API_ROUTES } from '../constants/api-routes';
import { Garage } from '../models/garage.model';

@Injectable({ providedIn: 'root' })
export class GarageService {
  constructor(private http: HttpClient) {}

  getAll(body: any = {}): Observable<Garage[]> {
    const url = `${API_ROUTES.BASE}${API_ROUTES.GARAGES_GET_ALL}`;
    return this.http.post<any>(url, body).pipe(map((res) => res.data || []));
  }

  loadAllFromDb(body: any = {}): Observable<Garage[]> {
    const url = `${API_ROUTES.BASE}${API_ROUTES.GARAGES_LOAD_ALL_FROM_DB}`;
    return this.http.post<any>(url, body).pipe(map((res) => res.data || []));
  }

  addGaragesRequest(garagesList: any[]): Observable<any> {
    const url = `${API_ROUTES.BASE}${API_ROUTES.GARAGES_ADD_REQUEST}`;
    const payload = { garagesList };
    return this.http.post<any>(url, payload).pipe(map((res) => res));
  }
}
