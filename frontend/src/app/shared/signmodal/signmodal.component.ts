import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UntypedFormBuilder, Validators, UntypedFormGroup } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-signmodal',
  templateUrl: './signmodal.component.html',
  styleUrls: ['./signmodal.component.scss']
})
export class SignmodalComponent implements OnInit {

  public isCollapsed = true;
  formData!: UntypedFormGroup;
  signupformData!:UntypedFormGroup;
  signInFormData!:UntypedFormGroup;
  signupPassfield!: boolean;
  fieldTextType:any;
  submitted = false;
  signupsubmit = false;

  constructor(public formBuilder: UntypedFormBuilder, private modalService: NgbModal, private api: ApiService) { }

  ngOnInit(): void {

    // Validation
    this.formData = this.formBuilder.group({
      // name: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

    this.signupformData = this.formBuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

    this.signInFormData = this.formBuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

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
    return this.formData.controls;
  }
  
  /**
 * Returns signup form
 */
   get signupform() {
    return this.signupformData.controls;
  }

  /**
 * submit signin form
 */
  signin() {
    if (this.formData.valid) {
      const message = this.formData.get('email')!.value;
      const pwd = this.formData.get('password')!.value;

      const loginData = {
        username: message,
        password: pwd
      }

      this.api.loginUser('Login', loginData).subscribe((data) => {
        console.log("INGRESAMOS: ", data);
        if (data.isSuccess) {
          Swal.fire("Bienvenido!");
          localStorage.setItem("Token", data.data);
        } else {
          Swal.fire({
            title: 'Error!',
            text: data.message,
            icon: 'error',
            confirmButtonText: 'OK'
          })
        }
        this.modalService.dismissAll();
      })

    }
    this.submitted = true;
  }

  signup(){
    if (this.signupformData.valid) {
      const message = this.signupformData.get('email')!.value;
      const pwd = this.signupformData.get('password')!.value;
      this.modalService.dismissAll();
    }
    this.signupsubmit = true;
  }

}
