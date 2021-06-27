import { Endereco } from './endereco.model';
export class Pessoa {
    constructor(
        public id?: number,
        public nome?: string,
        public email?: string,
        public telefoneAlternativo?: string,
        public telefoneCelular?: string,
        public cpf?: string,
        public dtNascimento?: string,
        public nomeFantasia?: string,
        //public cnpj?: string,
        //public inscMunicipal?: string,
        //public inscEstadual?: string,       
        public endereco?: Endereco[]
    ) {}
}