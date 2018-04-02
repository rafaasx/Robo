import { Cotovelo } from "./cotovelo";
import { Pulso } from "./pulso";
import { Lado } from "./enum";

export class Braco {
    constructor() {
        this.Cotovelo = new Cotovelo();
        this.Pulso = new Pulso();
        this.Nome = "";
        this.Lado = 1;
    }
    public Nome: string;
    public Cotovelo: Cotovelo;
    public Pulso: Pulso;
    public Lado: Lado;
}