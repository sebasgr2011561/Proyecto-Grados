import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.scss'
})
export class CategoriesComponent implements OnInit {
  listCategories: any = [];

  constructor(private api: ApiService, private route: Router) { }

  ngOnInit(): void {

    // When the user clicks on the button, scroll to the top of the document
    document.documentElement.scrollTop = 0;

    // Remove header account and wallet button
    document.querySelector('.account')?.classList.add('d-none')
    document.querySelector('.wallet')?.classList.add('d-none')
    document.querySelector('.connectwallet')?.classList.add('d-none')

    //Remove mail subscription footer
    document.querySelector('.footer .bg-dark')?.classList.remove('mt-n10', 'pt-10')
    document.querySelector('.footer.bg-secondary')?.classList.add('d-none')

    this.cargarCategories();
  }

  cargarCategories() {
    this.api.getData('Category').subscribe((data) => {
      this.listCategories = data.data;
    })
  }

  actualizarCategory(id: number) {
    this.route.navigate(['/editCategory', id]);
  }

  eliminarCategory(id: number) {
    this.api.deleteData('Category', id).subscribe((data) => {
      if (data.isSuccess) {
        Swal.fire(data.message, "", "success");
        this.cargarCategories();
      } else {
        Swal.fire({
          icon: "error",
          title: "Oops...",
          text: data.message
        });
      }
    })
  }
}
