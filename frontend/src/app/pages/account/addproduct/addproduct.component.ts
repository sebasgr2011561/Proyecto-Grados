import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators, UntypedFormArray, AbstractControl } from '@angular/forms';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { ApiService } from 'src/app/services/api.service';

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


  constructor(private formBuilder: UntypedFormBuilder, private api: ApiService) {
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
  }

  cargarCategorias() {
    this.api.getFullData('Category').subscribe((data) => {
      this.categorias = data.data;
    })
  }

  /**
   * Form data get
   */
  get form() {
    return this.productForm.controls;
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

}
