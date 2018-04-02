import { Component } from '@angular/core';
import { RoboService } from '../service/robo.service';
import { Robo } from '../dto/robo';
import { Contracao, Inclinacao, Rotacao, Lado } from '../dto/enum'

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
    public SelectedInclinacao: number;
    public SelectedRotacaoPulsoDireito: number;
    public SelectedRotacaoPulsoEsquerdo: number;
    public SelectedRotacaoCabeca: number;
    public SelectedContracaoDireito: number;
    public SelectedContracaoEsquerdo: number;
    getRobo() {
        console.log("getRobo:");
        this.roboService.getRobo().subscribe(res => {
            console.log("res: " + JSON.stringify(res));
            this.robo = Object.assign(new Robo(), res);
            this.SelectedInclinacao = this.robo.Cabeca.Inclinacao;
            this.SelectedRotacaoPulsoDireito = this.robo.BracoDireito.Pulso.Rotacao;
            this.SelectedRotacaoPulsoEsquerdo = this.robo.BracoEsquerdo.Pulso.Rotacao;
            this.SelectedRotacaoCabeca = this.robo.Cabeca.Rotacao;
            this.SelectedContracaoDireito = this.robo.BracoDireito.Cotovelo.Contracao;
            this.SelectedContracaoEsquerdo = this.robo.BracoEsquerdo.Cotovelo.Contracao;
            console.log("this.robo: " + JSON.stringify(this.robo));
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
        this.roboService.inclinarCabeca(this.SelectedInclinacao).subscribe(res => {
            console.log("res: " + JSON.stringify(res));
        });
        //getRobo();
    }
}
