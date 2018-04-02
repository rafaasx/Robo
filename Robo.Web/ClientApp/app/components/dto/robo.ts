import { Cabeca } from "./cabeca";
import { Braco } from "./braco";

export class Robo {
    constructor() {
        this.Cabeca = new Cabeca();
        this.BracoEsquerdo = new Braco();
        this.BracoDireito = new Braco();
        this.Nome = "";
    }
    public Nome: string;
    public Cabeca: Cabeca;
    public BracoEsquerdo: Braco;
    public BracoDireito: Braco;
}