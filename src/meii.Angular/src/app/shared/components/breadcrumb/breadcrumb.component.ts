import { Component, OnInit, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.css']
})
export class BreadcrumbComponent implements OnInit {
  @Input() detailsBreadcrump: {
    name,
    link,
  };
  constructor(private router: Router) { }

  ngOnInit() {
  }

   redirecionar(linkRouter: string) {
    this.router.navigateByUrl(linkRouter);
  }

}
