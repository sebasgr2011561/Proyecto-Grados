import { Component, OnInit } from '@angular/core';
import { product } from './data';

// Sweet Alert
import Swal from 'sweetalert2';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})

// Product Component
export class ProductComponent implements OnInit {
  products: any;
  sortfilter: any;
  isDesc: boolean = false;

  constructor(private api: ApiService) { }

  ngOnInit(): void {

    // When the user clicks on the button, scroll to the top of the document
    document.documentElement.scrollTop = 0;

    //Fetch Data
    // this.products = product;
    this.sortfilter = 'title';

    // set small decimal point
    this.cargarRecursos();
  }

  cargarRecursos() {
    this.api.getFullData('Course').subscribe((data) => {
      console.log('Cursos: ', data.data)
      this.products = data.data;
    })
  }

  //remove from products
  removeproduct(id: any) {
    Swal.fire({
      title: 'Estas seguro ?',
      text: '¿Estás seguro de eliminar este producto ?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: 'green',
      cancelButtonColor: 'rgb(243, 78, 78)',
      confirmButtonText: 'Si, Eliminar!',
    }).then((result) => {
      if (result.value) {
        Swal.fire({
          title: 'Eliminado!',
          text: 'Su curso ha sido eliminado.',
          confirmButtonColor: '#364574',
          icon: 'success',
        });
        this.products.splice(id, 1);
      }
    });
  }

  // Sort
}
