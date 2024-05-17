import { Component, OnInit } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

//Data Get
import { product } from './data';
import { CategoryService } from './category.service';
import { CategoryModel } from './category.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from 'src/app/services/api.service';
//import { cart } from '../cart/data';


@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss'],
  providers: [CategoryService, DecimalPipe]
})

// Category Component
export class CategoryComponent implements OnInit {


  productdetail: any;

  breadCrumbItems!: Array<{}>;
  products: any;
  selectedCategory: any;
  itemicon: any;
  isDesc: boolean = false;
  idProfesor!: number;

  // Table data
  CategoryList!: Observable<CategoryModel[]>;
  total: Observable<number>;

  idCategory!: number;

  constructor(public service: CategoryService, 
    private modalService: NgbModal, 
    private router: Router,
    private apiService: ApiService,
    private route: ActivatedRoute
  ) {
    this.CategoryList = service.countries$;
    this.total = service.total$;

    this.idCategory = +this.route.snapshot.paramMap.get('id')!;
    
  }

  redirectToAuctionLive(idRecurso: number) {
    this.router.navigate(['/recurso', idRecurso]);
}
  ngOnInit(): void {

    this.cargarRecursos();
    this.idProfesor = +localStorage.getItem('idRol')!;


    // When the user clicks on the button, scroll to the top of the document
    document.documentElement.scrollTop = 0;

    //Fethch Data
    // this.products = product
    this.selectedCategory = 'Popular'
    this.itemicon = 'thumb-up'

    /**
    * BreadCrumb
    */
    this.breadCrumbItems = [
      { label: 'Home', link: '' },
      { label: 'Market', link: '/' },
      { label: 'Inside category', active: true, link: '/category' }
    ];

    /**
    * fetches data
    */
    // setTimeout(() => {
    //   debugger;
    //   this.CategoryList.subscribe(x => {
    //     this.products = Object.assign([], x);
    //   });
    //   document.getElementById('elmLoader')?.classList.add('d-none')
    // }, 1200)

    // // set decimal point to small
    // setTimeout(() => {
    //   document.querySelectorAll(".price").forEach((e) => {
    //     let txt = e.innerHTML.split(".")
    //     e.innerHTML = txt[0] + ".<small>" + txt[1] + "</small>"
    //   })
    // }, 0);
  }

  cargarRecursos() {
    this.apiService.getData('Course', this.idCategory).subscribe((data) => {
      this.products = data.data.items;
      console.log('Category - Products: ', this.products);
    })
  }

  openModal(content: any, i: any) {
    this.productdetail = this.products[i]
    console.log('Products Details: ', this.productdetail);
    this.modalService.open(content, { size: 'lg', centered: true });
  }


  //filter dropdown
  Changecategory(item: any, icon: any, property: any) {
    this.selectedCategory = item
    this.itemicon = icon
    this.isDesc = !this.isDesc; //change the direction
    let direction = this.isDesc ? 1 : -1;
    this.service.products.sort((a: any, b: any) => {
      if (a[property] < b[property]) {
        return -1 * direction;
      }
      else if (a[property] > b[property]) {
        return 1 * direction;
      }
      else {
        return 0;
      }
    });
  }

  //add to cart
}
