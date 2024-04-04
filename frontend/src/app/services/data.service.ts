import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class SharingDataService {
    data: Array<any> = [];
    idUsuarioEdit: number = 0;

    constructor() { }

    setIdUsuarioEdit(idUsuario: number) {
        this.idUsuarioEdit = idUsuario;
    }
}