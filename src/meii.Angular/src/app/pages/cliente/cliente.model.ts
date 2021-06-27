import { Pessoa } from '../model/pessoa.model';
export class Cliente {
    constructor(
        public id?: number,
        public codigo?: string,
        public appTenantId?: number,
        public pessoa?: Pessoa,
    ) {}
}




