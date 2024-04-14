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

    bodyRequest: any = {
        numPage: 1,
        numRecordsPAge: 10,
        order: 'asc',
        sort: 'Id', 
    };

    constructor(private http: HttpClient) { }

    getData(controller: string) : Observable<any> { 
        const url = this.apiUrl + this.api + controller + '/';
        return this.http.post<any>(url, this.bodyRequest);
    }

    getFullData(controller: string) : Observable<any> { 
        const url = this.apiUrl + this.api + controller + '/select';
        return this.http.get<any>(url)
    }

    getFullDataById(controller: string, id:number) : Observable<any> { 
        const url = this.apiUrl + this.api + controller + '/SelectByProfesorId/' + id;
        return this.http.get<any>(url)
    }

    getDataById(controller: string, id: number) : Observable<any> { 
        const url = this.apiUrl + this.api + controller + '/' + id;
        return this.http.get<any>(url)
    }

    createData(controller: string, data: any) : Observable<any> { 
        const url = this.apiUrl + this.api + controller + '/Register';
        return this.http.post<any>(url, data);
    }

    updateData(controller: string, id: number, data: any) : Observable<any> { 
        const url = this.apiUrl + this.api + controller + '/Update/' + id;
        return this.http.put<any>(url, data);
    }

    deleteData(controller: string, id: number) : Observable<any> { 
        const url = this.apiUrl + this.api + controller + '/Delete/' + id;
        return this.http.put<any>(url, id);
    }

    // LOGIN
    registerUser() {}

    loginUser(controller: string, userRequestData: any): Observable<any> {
        const urlLogin = this.apiUrl + this.api + controller + '/Generate';
        return this.http.post<any>(urlLogin, userRequestData);
    }
}