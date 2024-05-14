import { Component, Input, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, FormArray, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { SharingDataService } from 'src/app/services/data.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-settings',
  templateUrl: './setting.component.html',
  styleUrls: ['./setting.component.scss']
})

// Setting Component
export class SettingComponent implements OnInit {

  breadCrumbItems!: any;
  submitted = false;
  userForm!: UntypedFormGroup;
  userId: any;
  roles: any;

  constructor(private formBuilder: UntypedFormBuilder, 
    private api: ApiService, 
    private dataService: SharingDataService,
    private route: Router) {
    
    this.userId = this.dataService.idUsuarioEdit == 0 ? localStorage.getItem("userId") : this.dataService.idUsuarioEdit
  }

  ngOnInit(): void {

    // When the user clicks on the button, scroll to the top of the document
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;

    // Remove header account and wallet button
    document.querySelector('.account')?.classList.add('d-none')
    document.querySelector('.wallet')?.classList.add('d-none')
    document.querySelector('.connectwallet')?.classList.add('d-none')

    //Remove mail subscription footer
    document.querySelector('.footer .bg-dark')?.classList.remove('mt-n10', 'pt-10')
    document.querySelector('.footer.bg-secondary')?.classList.add('d-none')

    /**
    * BreadCrumb
    */
    this.breadCrumbItems = [
      { label: 'Home', link: '/' },
      { label: 'Marketplace', link: '/' },
      { label: 'Single Project', active: true, link: '/Single Project' }
    ];

    /**
   * Form Validation
   */
    this.userForm = this.formBuilder.group({
      uid: ['', [Validators.required]],
      rol: ['', [Validators.required]],
      name: ['', [Validators.required]],
      lastname: ['', [Validators.required]],
      cellular: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      bio: ['', [Validators.required]],
      status: ['', [Validators.required]]
    });

    this.consultarRoles();
    
    if (this.userId !== 0) {
      this.consultarUsuario();
    }

  }

  consultarRoles() {
    this.api.getFullData('Role').subscribe((data) => {
      this.roles = data.data;
    })
  }

  consultarUsuario() {
    this.api.getDataById('User',  parseInt(this.userId)).subscribe((data) => {
      this.userForm.controls['uid'].setValue(data.data.idUsuario);
      this.userForm.controls['name'].setValue(data.data.nombres);
      this.userForm.controls['lastname'].setValue(data.data.apellidos);
      this.userForm.controls['cellular'].setValue(data.data.celular);
      this.userForm.controls['email'].setValue(data.data.email);
      this.userForm.controls['password'].setValue('');
      this.userForm.controls['bio'].setValue(data.data.biografia);
    })
  }

  /**
 * Form data get
 */
  get form() {
    return this.userForm.controls;
  }

  saveUser() {
    let dataUpdate = {
      idRol: this.userForm.controls['rol'].value,
      nombres: this.userForm.controls['name'].value,
      apellidos: this.userForm.controls['lastname'].value,
      celular: this.userForm.controls['cellular'].value,
      email: this.userForm.controls['email'].value,
      password: this.userForm.controls['password'].value,
      biografia: this.userForm.controls['bio'].value,
      imagen: this.imageURL,
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
        this.api.updateData('User', this.userId, dataUpdate).subscribe((data) => {
          if (data.isSuccess) {
            Swal.fire(data.message, "", "success");
            this.route.navigate(['/usuarios']);
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

  // File Upload
  imageURL: string | undefined;
  fileChange(event: any) {
    let fileList: any = (event.target as HTMLInputElement);
    let file: File = fileList.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      this.imageURL = reader.result as string;
      document.querySelectorAll('#user_profile').forEach((element: any) => {
        element.src = this.imageURL;
        debugger;
      });
    }
    reader.readAsDataURL(file)
  }

}
