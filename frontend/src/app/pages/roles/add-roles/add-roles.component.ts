import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-roles',
  templateUrl: './add-roles.component.html',
  styleUrl: './add-roles.component.scss'
})
export class AddRolesComponent implements OnInit {

  roleForm!: UntypedFormGroup;
  submitted = false;

  constructor(
    private formBuilder: UntypedFormBuilder, 
    private api: ApiService, 
    private route: Router
  ) { }

  ngOnInit(): void {
    document.documentElement.scrollTop = 0;

    this.roleForm = this.formBuilder.group({
      ids: [''],
      descripcion: ['', [Validators.required]]
    });
  }

  get form() {
    return this.roleForm.controls;
  }

  AddRol() {

    let rolData = {
      descripcion: this.roleForm.controls['descripcion'].value
    }

    Swal.fire({
      title: "¿Deseas guardar los cambios?",
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: "Guardar",
      denyButtonText: `No guardar`
    }).then((result) => {
      if (result.isConfirmed) {
        this.api.createData('Role', rolData).subscribe((data) => {
          if (data.isSuccess) {
            Swal.fire(data.message, "", "success");
            this.route.navigate(['/usuarios'])
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
