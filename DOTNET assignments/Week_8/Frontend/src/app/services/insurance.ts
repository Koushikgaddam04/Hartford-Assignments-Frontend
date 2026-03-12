import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class Insurance {
  private apiUrl = 'https://localhost:7276/api'; 

  constructor(private http: HttpClient) {}

  private getHeaders() {
    const token = localStorage.getItem('token');
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  // --- ADMIN METHODS ---
  getPendingCustomers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Auth/customers/pending`, { headers: this.getHeaders() });
  }

  getAgents(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Auth/agents`, { headers: this.getHeaders() });
  }

  assignAgent(customerId: number, agentId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/Auth/assign-agent`, { customerId, agentId }, { headers: this.getHeaders() });
  }

  getAllPolicies(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Policy/all`, { headers: this.getHeaders() });
  }

  // --- AGENT METHODS (Fixed these for your errors) ---
  getPoliciesForAgent(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Policy/agent-view`, { headers: this.getHeaders() });
  }

  updatePolicyStatus(policyId: number, status: string): Observable<any> {
    // We wrap the status in quotes because backend expects a string body
    return this.http.put(`${this.apiUrl}/Policy/${policyId}/status`, `"${status}"`, { 
      headers: this.getHeaders().set('Content-Type', 'application/json') 
    });
  }

  // --- CUSTOMER METHODS ---
  createPolicy(policyData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/Policy`, policyData, { headers: this.getHeaders() });
  }

  getCustomerPolicies(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Policy/my-policies`, { headers: this.getHeaders() });
  }
}