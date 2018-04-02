import { Inclinacao, Rotacao } from "./enum";

export class Cabeca {
    constructor() {
        this.Nome = "";
        this.Inclinacao = 1;
        this.Rotacao = 1;
    }
    public Nome: string;
    public Inclinacao: Inclinacao;
    public Rotacao: Rotacao;
}