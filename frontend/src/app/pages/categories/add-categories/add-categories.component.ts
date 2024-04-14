import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-categories',
  templateUrl: './add-categories.component.html',
  styleUrl: './add-categories.component.scss'
})
export class AddCategoriesComponent implements OnInit {

  categoryForm!: UntypedFormGroup;
  submitted = false;

  constructor(
    private formBuilder: UntypedFormBuilder, 
    private api: ApiService, 
    private route: Router
  ) { }

  ngOnInit(): void {
    document.documentElement.scrollTop = 0;

    this.categoryForm = this.formBuilder.group({
      id: [''],
      descripcion: ['', [Validators.required]]
    });
  }

  get form() {
    return this.categoryForm.controls;
  }

  AddCategory() {

    let categoryData = {
      nombreCategoria: this.categoryForm.controls['descripcion'].value
    }

    Swal.fire({
      title: "¿Deseas guardar los cambios?",
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: "Guardar",
      denyButtonText: `No guardar`
    }).then((result) => {
      if (result.isConfirmed) {
        this.api.createData('Category', categoryData).subscribe((data) => {
          if (data.isSuccess) {
            Swal.fire(data.message, "", "success");
            this.route.navigate(['/categories'])
          } else {
            Swal.fire({
              icon: "error",
              title: "Oops...",
              text: data.message
            });
          }
        })
      } else if (result.isDenied) {
        Swal.fire("No se guardaron los cambios", "", "info");
      }
    })
  }
}
