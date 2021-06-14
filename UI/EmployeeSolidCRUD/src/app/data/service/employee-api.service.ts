import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../type/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeApiService {
  ApiUrl="https://localhost:5001/api/employees";

  constructor(private httpClient: HttpClient) { }

  public GetAll(): Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.ApiUrl);
  }

  public Get(Id: number): Observable<Employee>{
    return this.httpClient.get<Employee>(this.ApiUrl + Id);
  }

  public Create(Employee: Object): Observable<Employee>{
    return this.httpClient.post<Employee>(this.ApiUrl, Employee);
  }

  public Delete(Id: number): Observable<Employee>{
    return this.httpClient.delete<Employee>(this.ApiUrl + "/" + Id);
  }

  public Update(Employee: Employee, Id: number): Observable<Employee>{
    return this.httpClient.put<Employee>(this.ApiUrl + "/" + Id, Employee);
  }
}
