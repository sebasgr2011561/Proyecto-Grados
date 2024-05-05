import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UntypedFormBuilder, Validators, UntypedFormGroup } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-usermodal',
  templateUrl: './usermodal.component.html',
  styleUrl: './usermodal.component.scss'
})
export class UsermodalComponent {
  public isCollapsed = true;
  userForm!: UntypedFormGroup;
  signupformData!:UntypedFormGroup;
  signInFormData!:UntypedFormGroup;
  signupPassfield!: boolean;
  fieldTextType:any;
  submitted = false;
  signupsubmit = false;
  userId:any;
  userName:any;
  jwtDecode:any;
  bio:any;
  img:any;

  @Input() user = null;
  userParameter = null;
  @Output() onResult = new EventEmitter<any>();
  roles: any;

  constructor(public formBuilder: UntypedFormBuilder, 
    private modalService: NgbModal, 
    private api: ApiService,
    private route: Router) { }

  ngOnInit(): void {

    // Validation
    this.userForm = this.formBuilder.group({
      uid: ['', [Validators.required]],
      rol: ['', [Validators.required]],
      name: ['', [Validators.required]],
      lastname: ['', [Validators.required]],
      cellular: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

    this.cargarUsuario();
    this.cargarRoles();
  }

  cargarRoles() {
    this.api.getFullData('Role').subscribe((data) => {
      this.roles = data.data;
    })
  }

  cargarUsuario() {
    this.api.getDataById('User', 4).subscribe((data) => {
      this.userForm.controls['uid'].setValue(data.data.idUsuario);
      this.userForm.controls['name'].setValue(data.data.nombres);
      this.userForm.controls['lastname'].setValue(data.data.apellidos);
      this.userForm.controls['cellular'].setValue(data.data.celular);
      this.userForm.controls['email'].setValue(data.data.email);
      this.userForm.controls['password'].setValue('');
      this.bio = data.data.biografia;
    })
  }

  /**
  * Close modal
  */
   closemodal() {
    // this.submitted = false;
    this.modalService.dismissAll();
  }

  toggleFieldTextType(){
    this.fieldTextType = !this.fieldTextType
  }

    /**
   * Password Hide/Show
   */
     togglesignupPassfield() {
      this.signupPassfield = !this.signupPassfield;
    }

  /**
 * Returns form
 */
  get form() {
    return this.userForm.controls;
  }

  /**
 * Returns signup form
 */
   get signupform() {
    return this.signupformData.controls;
  }

  actualzarUsuario() {
    let dataCreate = {
      idRol: this.userForm.controls['rol'].value,
      nombres: this.userForm.controls['name'].value,
      apellidos: this.userForm.controls['lastname'].value,
      celular: this.userForm.controls['cellular'].value,
      email: this.userForm.controls['email'].value,
      password: this.userForm.controls['password'].value,
      biografia: this.bio,
      estado: true
    }

    Swal.fire({
      title: "¿Deseas guardar los cambios?",
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: "Guardar",
      denyButtonText: `No guardar`
    }).then((result) => {
      if (result.isConfirmed) {
        this.api.updateData('User', 4, dataCreate).subscribe((data) => {
          if (data.isSuccess) {
            Swal.fire(data.message, "", "success");
            this.closemodal();
            window.location.reload();
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

    this.submitted = true
  }


}
