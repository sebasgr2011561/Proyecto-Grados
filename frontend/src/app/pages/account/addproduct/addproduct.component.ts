import { UntypedFormBuilder, UntypedFormGroup, Validators, UntypedFormArray, AbstractControl } from '@angular/forms';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbNavChangeEvent } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { RecursomodalComponent } from 'src/app/shared/recursomodal/recursomodal.component';


// Data Get
//import { product } from '../product/data';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.scss'],
})

// Addproduct Component
export class AddproductComponent implements OnInit {
  productForm!: UntypedFormGroup;
  submitted = false;

  userForm: UntypedFormGroup;
  selectedcategory: any;
  itemData!: UntypedFormGroup;

  categorias: any;

  public isCollapsed = true;
  formData!: UntypedFormGroup;
  signupformData!:UntypedFormGroup;
  signInFormData!:UntypedFormGroup;
  signupPassfield!: boolean;
  fieldTextType:any;
  signupsubmit = false;
  userId:any;
  userName:any;
  jwtDecode:any;


  constructor(private route: Router, private modalService: NgbModal,private formBuilder: UntypedFormBuilder, private api: ApiService) {
    this.selectedcategory = 'ETH'

    this.userForm = this.formBuilder.group({
      sizes: this.formBuilder.array([
        this.formBuilder.control(null)
      ])
    })


  }

  ngOnInit(): void {

    // When the user clicks on the button, scroll to the top of the document
    document.documentElement.scrollTop = 0;

    /**
     * Form Validation
     */
    this.productForm = this.formBuilder.group({
      ids: [''],
      name: ['', [Validators.required]],
      productss: ['', [Validators.required]],
      description: ['', [Validators.required]],
      standardliprice: ['', [Validators.required]],
      extendedliprice: ['', [Validators.required]],
      tags: ['', [Validators.required]],
      salefile: ['', [Validators.required]],
    });

    this.cargarCategorias();

        //modal validations
        this.formData = this.formBuilder.group({
          name: ['', [Validators.required]],
          email: ['', [Validators.required]],
          password: ['', [Validators.required]]
        });

        this.signupformData = this.formBuilder.group({
          name: ['', [Validators.required]],
          email: ['', [Validators.required]],
          password: ['', [Validators.required]]
        });
  }

  cargarCategorias() {
    this.api.getFullData('Category').subscribe((data) => {
      this.categorias = data.data;
    })
  }

  /**
   * Form data get
   */
  openModal() {
    // this.submitted = false;
    this.modalService.open(RecursomodalComponent, { size: 'lg', centered: true });
  }

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

  // File Upload
  imageURL: string | undefined;
  fileChange(event: any) {
    let fileList: any = event.target as HTMLInputElement;
    let file: File = fileList.files[0];
    const reader = new FileReader();
    reader.onload = () => {
      this.imageURL = reader.result as string;
    }
    reader.readAsDataURL(file);
  }

  /**
   * Save user
   */
  AddProduct() {
    this.submitted = true;
  //  product.push(this.productForm.value);
  }

  files: File[] = [];

  onSelect(event: any) {
    this.files.push(...event.addedFiles);
  }

  onRemove(event: any) {
    this.files.splice(this.files.indexOf(event), 1);
  }
  getItemFormControls(): AbstractControl[] {
    return (<UntypedFormArray>this.userForm.get('sizes')).controls
  }

  createitem() {
    if (this.itemData.valid) {
    }
    this.submitted = true;
  }
  changeprice(event: any) {
    this.selectedcategory = event.target.closest('span')?.innerHTML
  }

  // Add Item
  addItem(): void {
    (this.userForm.get('sizes') as UntypedFormArray).push(
      this.formBuilder.control(null)
    );
  }

  // Delete Item
  removeItem(index: any) {
    (this.userForm.get('sizes') as UntypedFormArray).removeAt(index);
  }

  signin() {
    if (this.formData.valid) {
      const message = this.formData.get('email')!.value;
      const pwd = this.formData.get('password')!.value;
      this.modalService.dismissAll();
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
