import { DlDateTimeDateModule } from 'angular-bootstrap-datetimepicker';
import { Pessoa } from './../../model/pessoa.model';
import { Endereco } from './../../model/endereco.model';
import { PessoaFisica } from './../../model/pessoaFisica.model';
import { Router, ActivatedRoute } from '@angular/router';
import { ClienteService } from './../cliente.service';
import { Cliente } from './../cliente.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { EventEmitter } from 'protractor';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent implements OnInit {
  clienteform: FormGroup;
  pessoaform: FormControl;
  cliente: Cliente = new Cliente();
  btnDetailsForm = { name: 'Salvar', link: 'cliente/novo'};
  breadcrumpDetails = {name: 'Cliente', link: 'cliente'};
  listaEnderecos: Endereco[] = [];


  constructor(
    private clienteService: ClienteService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    ) { }

  ngOnInit() {
    const clienteId = +this.route.snapshot.paramMap.get("id");
    this.criarClienteForm();
    if (clienteId > 0) {
      this.buscarPorId(clienteId);
    }
  }

  onSubmit($event) {
    this.cliente = this.clienteform.value;
    if ($event === 'new') {
      this.criarCliente(this.cliente, 0);
    } else {
      this.editarCliente(this.cliente);
    }
  }

  private criarClienteForm() {
    this.clienteform = this.formBuilder.group({
      id: [null],
      codigo:[null],
      pessoa: this.formBuilder.group({
        nome:[null],
        cpf : [null, [Validators.required]],
        email: [null, [Validators.required]],
        telefoneAlternativo: [null],
        telefoneCelular: [null],
        //endereco: [],
        telCelular: [null],
        dtNascimento: [null],
      })
      
    });
  }

  public popularClienteForm(cliente: Cliente) {
    this.listaEnderecos = cliente.pessoa.endereco;
    
    this.clienteform.patchValue({
        id: cliente.id,
        codigo: cliente.codigo,
        pessoa: {
          nome: cliente.pessoa.nome,
          cpf: cliente.pessoa.cpf,
          email: cliente.pessoa.email,
          telefoneAlternativo : cliente.pessoa.telefoneAlternativo,
          //endereco: cliente.pessoa.endereco,
          telefoneCelular: cliente.pessoa.telefoneCelular,
          dtNascimento: cliente.pessoa.dtNascimento,
        }    
      });
  }

  private newCliente() {
    const endereco1: Endereco[] = [];
    const cliente: Cliente = new Cliente();
    cliente.codigo = '1222',
    cliente.pessoa = new Pessoa(
      null,
      this.clienteform.get('pessoa.nome').value,
      this.clienteform.get('pessoa.email').value,
      this.clienteform.get('pessoa.telefoneAlternativo').value,
      this.clienteform.get('pessoa.telefoneCelular').value,
      this.clienteform.get('pessoa.cpf').value,
     // this.clienteform.get('cnpj').value,
      this.clienteform.get('pessoa.dtNascimento').value,
     // this.clienteform.get('nomeFantasia').value,
     // this.clienteform.get('inscMunicipal').value,
     // this.clienteform.get('inscEstadual').value,
    );

    this.criarCliente(cliente, 0);
  }

  public buscarPorId(Id: number) {
   return this.clienteService.buscarClienteId(Id)
    .subscribe(res => {
      this.cliente = res.data;
      this.popularClienteForm(this.cliente);
    });

  }

  public criarCliente(cliente: Cliente , tipoPessoa: number) {
    if (tipoPessoa === 0) {
      this.clienteService.criarClientePessoaFisica(cliente);
    } else {
      this.clienteService.criarClientePessoaJuridica(cliente);
    }
  }

  editarCliente(cliente: Cliente ) {
    this.clienteService.editarCliente(cliente)
    .subscribe(res => {
      this.toastr.success(res.data);
      this.router.navigateByUrl('cliente');
    });
  }


}



// cliente.pessoa.nome =  this.clienteform.get('nome').value,
//     cliente.pessoa.email =  this.clienteform.get('email').value,
//     cliente.pessoa.telefoneCelular = this.clienteform.get('telCelular').value,
//     cliente.pessoa.telefoneFixo = this.clienteform.get('telResidencial').value,
//     cliente.pessoa.endereco = endereco1,
//     cliente.pessoa.cpf = this.clienteform.get('cpf').value,
//     cliente.pessoa.rg = this.clienteform.get('rg').value,
//     cliente.pessoa.cnpj = this.clienteform.get('cnpj').value,
//     cliente.pessoa.dtNascimento =  this.clienteform.get('dtNascimento').value,
//     cliente.pessoa.nomeFantasia = this.clienteform.get('nomeFantasia').value,
//     cliente.pessoa.inscEstadual = this.clienteform.get('inscEstadual').value,
//     cliente.pessoa.inscMunicipal = this.clienteform.get('inscMunicipal').value,