import { Component, OnInit } from '@angular/core';
import { product } from './data';

// Sweet Alert
import Swal from 'sweetalert2';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CalificacionmodalComponent } from 'src/app/shared/calificacionmodal/calificacionmodal.component';
import { SharingDataService } from 'src/app/services/data.service';

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
  idRolEstudiante!: number;
  userId!: number;

  constructor(private api: ApiService,
    private route: Router,
    private modalService: NgbModal,
    private dataApi: SharingDataService
  ) { 
    this.idRolEstudiante = +localStorage.getItem('idRol')!;
    this.userId = +localStorage.getItem('userId')!;
  }

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
    if (this.idRolEstudiante !== 3) {
      this.api.getFullData('Course').subscribe((data) => {
        console.log('Cursos: ', data.data)
        this.products = data.data;
      })
    } else {
      this.api.getDataAssignments("Assignment", this.userId).subscribe((data) => {
        console.log('Cursos Asignados: ', data.data)
        this.products = data.data;
      })
    }
  }

  editproduct(id:number) {
    this.route.navigate(['/addproduct', id]);
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
  openModal(id: number) {
    console.log('IdCurso: ', id)
    this.dataApi.idRecurso = id;
    this.modalService.open(CalificacionmodalComponent, { size: 'md', centered: true });
  }
}
