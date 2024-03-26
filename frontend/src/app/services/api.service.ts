import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    api = "api/";
    apiUrl = environment.api;

    constructor(private http: HttpClient) { }

    getData(controller: string) { 

    }

    getDataById(controller: string, id: number) : Observable<any> { 
        const url = this.apiUrl + this.api + controller + '/' + id;
        return this.http.get<any>(url)
    }

    createData(controller: string) { }

    updateData(controller: string) { } 

    deleteData(controller: string) { }

    // LOGIN
    registerUser() {}

    loginUser(controller: string, userRequestData: any): Observable<any> {
        const urlLogin = this.apiUrl + this.api + controller + '/Generate';
        return this.http.post<any>(urlLogin, userRequestData);
    }
}