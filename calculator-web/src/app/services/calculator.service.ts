import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from '@environments/environment';
import { AvailableOperation } from '@app/interfaces/available-operation.interface';
import { CalculationModel, CalculationResult } from '@app/interfaces/calculation-model.interface';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getOperations(): Observable<AvailableOperation[]> {
    return this.http.get<AvailableOperation[]>(`${this.baseUrl}operations`);
  }

  calculate(calculation: CalculationModel): Observable<CalculationResult> {
    return this.http.post<CalculationResult>(`${this.baseUrl}`, calculation).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
      return throwError(() => error.error);
  }  
}