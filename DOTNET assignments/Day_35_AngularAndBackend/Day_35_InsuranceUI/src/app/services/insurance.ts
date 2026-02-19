import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Insurance {
  private apiUrl = 'https://localhost:7089/api'; // Use the real port from your screenshot

  constructor(private http: HttpClient) { }

  // This method allows the 'Create' form to send data to the database
  createPolicy(policy: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/policies`, policy);
  }

  getPolicies(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/policies`);
  }
}