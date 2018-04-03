import { Component } from '@angular/core';
import { RoboService } from '../service/robo.service';
import { Robo } from '../dto/robo';
import { Contracao, Inclinacao, Rotacao, Lado } from '../dto/enum'
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})

export class HomeComponent {
    public robo: Robo = new Robo();
    public Contracao: typeof Contracao = Contracao;
    public Inclinacao: typeof Inclinacao = Inclinacao;
    public Rotacao: typeof Rotacao = Rotacao;
    public Lado: typeof Lado = Lado;
    public optionsInclinacao: string[];
    public optionsRotacao: string[];
    public optionsContracao: string[];
    public SelectedInclinacao: Inclinacao;
    public SelectedRotacaoPulsoDireito: Rotacao;
    public SelectedRotacaoPulsoEsquerdo: Rotacao;
    public SelectedRotacaoCabeca: Rotacao;
    public SelectedContracaoDireito: Contracao;
    public SelectedContracaoEsquerdo: Contracao;
    public Mensagem: string = "";
    getRobo() {
        this.roboService.getRobo().subscribe(res => {
            this.robo = Object.assign(new Robo(), res);
            this.SelectedInclinacao = this.robo.Cabeca.Inclinacao;
            this.SelectedRotacaoPulsoDireito = this.robo.BracoDireito.Pulso.Rotacao;
            this.SelectedRotacaoPulsoEsquerdo = this.robo.BracoEsquerdo.Pulso.Rotacao;
            this.SelectedRotacaoCabeca = this.robo.Cabeca.Rotacao;
            this.SelectedContracaoDireito = this.robo.BracoDireito.Cotovelo.Contracao;
            this.SelectedContracaoEsquerdo = this.robo.BracoEsquerdo.Cotovelo.Contracao;
        });
    }

    constructor(private roboService: RoboService) { }

    ngOnInit() {
        this.optionsInclinacao = Object.keys(this.Inclinacao).filter(Number);
        this.optionsRotacao = Object.keys(this.Rotacao).filter(Number);
        this.optionsContracao = Object.keys(this.Contracao).filter(Number);
        this.getRobo();
    }

    inclinarCabeca() {
        this.Mensagem = "";
        this.roboService.inclinarCabeca(this.SelectedInclinacao)
            .catch((error: any) => this.Mensagem = JSON.parse(error._body).Message)
            .finally(() => { this.getRobo();  })
            .subscribe(res => this.getRobo(), error => JSON.stringify("error: " + error));
    }

    rotacionarCabeca() {
        this.Mensagem = "";
        this.roboService.rotacionarCabeca(this.SelectedRotacaoCabeca)
            .catch((error: any) => this.Mensagem = JSON.parse(error._body).Message)
            .finally(() => { this.getRobo(); })
            .subscribe(res => this.getRobo(), error => JSON.stringify("error: " + error));
    }


    contrairCotovelo(selectedContrair: Contracao, lado: Lado) {
        this.Mensagem = "";
        this.roboService.contrairCotovelo(selectedContrair, lado)
            .catch((error: any) => this.Mensagem = JSON.parse(error._body).Message)
            .finally(() => { this.getRobo(); })
            .subscribe(res => this.getRobo(), error => JSON.stringify("error: " + error));
    }

    rotacionarPulso(selectedRotacionar: Rotacao, lado: Lado) {
        this.Mensagem = "";
        this.roboService.rotacionarPulso(selectedRotacionar, lado)
            .catch((error: any) => this.Mensagem = JSON.parse(error._body).Message)
            .finally(() => { this.getRobo(); })
            .subscribe(res => this.getRobo(), error => JSON.stringify("error: " + error));
    }
}
