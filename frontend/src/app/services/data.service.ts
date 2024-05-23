import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class SharingDataService {
    data: Array<any> = [];
    idUsuarioEdit: number = 0;
    private _idRecurso!: number;

    constructor() { }

    setIdUsuarioEdit(idUsuario: number) {
        this.idUsuarioEdit = idUsuario;
    }

    public get idRecurso(): number {
        return this._idRecurso;
    }
    
    public set idRecurso(value: number) {
        this._idRecurso = value;
    }
}