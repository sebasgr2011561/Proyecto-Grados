import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UntypedFormBuilder, UntypedFormGroup, Validators, UntypedFormArray, AbstractControl } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';


@Component({
  selector: 'app-recursomodal',
  templateUrl: './recursomodal.component.html',
  styleUrl: './recursomodal.component.scss'
})

export class RecursomodalComponent {
  productForm!: UntypedFormGroup;

  selectedcategory: any;
  itemData!: UntypedFormGroup;
  userForm: UntypedFormGroup;

  categorias: any;
  public isCollapsed = true;
  formData!: UntypedFormGroup;
  signupformData!:UntypedFormGroup;
  signInFormData!:UntypedFormGroup;
  signupPassfield!: boolean;
  fieldTextType:any;
  submitted = false;
  signupsubmit = false;
  userId:any;
  userName:any;

  constructor(public formBuilder: UntypedFormBuilder, private modalService: NgbModal, private api: ApiService, private router: Router) {
    this.userForm = this.formBuilder.group({
      sizes: this.formBuilder.array([
        this.formBuilder.control(null)
      ])
    })
   }

  ngOnInit(): void {

    // Validation
    this.formData = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

    this.signupformData = this.formBuilder.group({
      name: ['', [Validators.required]],
      lastname: ['', [Validators.required]],
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
    }

    signup(){
    }
      // Delete Item
  removeItem(index: any) {
    (this.userForm.get('sizes') as UntypedFormArray).removeAt(index);
  }

  getItemFormControls(): AbstractControl[] {
    return (<UntypedFormArray>this.userForm.get('sizes')).controls
  }
    // Add Item
    addItem(): void {
      (this.userForm.get('sizes') as UntypedFormArray).push(
        this.formBuilder.control(null)
      );
    }

}

