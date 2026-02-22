import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InsuranceService {
  private apiUrl = 'https://localhost:7089/api';

  constructor(private http: HttpClient) { }

  // Customers
  getAllCustomers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Customer`);
  }

  getCustomersByAgent(agentId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Customer/agent/${agentId}`);
  }

  getCustomerProfile(userId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Customer/user/${userId}`);
  }

  createCustomerProfile(profile: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Customer`, profile);
  }

  assignAgentToCustomer(customerId: number, agentId: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/Customer/${customerId}/assign-agent/${agentId}`, {});
  }

  // Policies
  getAllPolicies(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Policy`);
  }

  getPoliciesByCustomer(customerId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Policy/customer/${customerId}`);
  }

  getPoliciesByAgent(agentId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Policy/agent/${agentId}`);
  }

  createPolicy(policy: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Policy`, policy);
  }

  updatePolicyStatus(policyId: number, status: string): Observable<any> {
    return this.http.put(`${this.apiUrl}/Policy/${policyId}/status`, { status });
  }
}
