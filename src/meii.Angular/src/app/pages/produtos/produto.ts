import { Categoria } from '../categoria/categoria.model';

export class Produto {
    public id?: number;
    public nome?: string;
    public descricao?: string;
    public dataCadastro?: Date;
    public quantidade?: number;
    public valor?: number;
    public categoriaId?: number;
    public categoria?: Categoria;
}