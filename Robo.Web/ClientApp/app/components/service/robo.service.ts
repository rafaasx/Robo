import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
//import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/BehaviorSubject'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import { Robo } from '../dto/robo';
import { Inclinacao, Lado, Rotacao, Contracao } from '../dto/enum';

@Injectable()
export class RoboService {
    private _apiURL: string = "http://localhost/RoboWebAPI/api/Robo";
    private httpOptions = {
        headers: new Headers({
            'Content-Type': 'application/json'
        })
    };
    inclinarCabeca(inclinacao: Inclinacao): Observable<any> {
        
        console.log("inclinarCabeca: " + inclinacao);
        return this.http.post(this._apiURL + "?inclinacao=" + inclinacao, { "inclinacao": inclinacao })
            .map((res: Response) => res.json());
    }

    rotacionarCabeca(rotacao: Rotacao) {
        return this.http.post(this._apiURL + "?rotacaoCabeca=" + rotacao, {})
            .map((res: Response) => res.json());
    }

    contrairCotovelo(contracao: Contracao, lado: Lado): Observable<any> {
        return this.http.post(this._apiURL + "?contracao=" + contracao + "&lado=" + lado, {})
            .map((res: Response) => res.json());
    }

    rotacionarPulso(rotacao: Rotacao, lado: Lado): Observable<any> {
        return this.http.post(this._apiURL + "?rotacaoPulso=" + rotacao + "&lado=" + lado, {})
            .map((res: Response) => res.json());
    }

    constructor(private http: Http) { }

    getRobo(): Observable<Robo> {
        return this.http.get(this._apiURL)
            .map((res: Response) => <Robo>res.json())
            .catch((error: any) => Observable.throw(JSON.stringify(error.json()) + '.Server error.'));
    }
}