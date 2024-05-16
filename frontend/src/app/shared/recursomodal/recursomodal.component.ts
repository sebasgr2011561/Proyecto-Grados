import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UntypedFormBuilder, UntypedFormGroup, Validators, UntypedFormArray, AbstractControl, FormArray, FormGroup, FormControl } from '@angular/forms';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { SharingDataService } from 'src/app/services/data.service';


@Component({
  selector: 'app-recursomodal',
  templateUrl: './recursomodal.component.html',
  styleUrl: './recursomodal.component.scss'
})

export class RecursomodalComponent {
  productForm!: UntypedFormGroup;

  selectedcategory: any;
  itemData!: UntypedFormGroup;
  moduleForm!: UntypedFormGroup;

  categorias: any;
  public isCollapsed = true;
  formData!: UntypedFormGroup;
  signupformData!: UntypedFormGroup;
  signInFormData!: UntypedFormGroup;
  signupPassfield!: boolean;
  fieldTextType: any;
  submitted = false;
  signupsubmit = false;
  userId: any;
  userName: any;

  listModulos: any[] = [];

  constructor(public formBuilder: UntypedFormBuilder, 
    private modalService: NgbModal, 
    private api: ApiService, 
    private route: Router,
    private dataApi: SharingDataService,
    
  ) { }

  ngOnInit(): void {

    this.crearFormulario();

    // Validation
    this.formData = this.formBuilder.group({
      nombre: ['', [Validators.required]],
      url: ['', [Validators.required]]
    });

    this.signupformData = this.formBuilder.group({
      name: ['', [Validators.required]],
      lastname: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  crearFormulario() {
    this.moduleForm = this.formBuilder.group({
      modulos: new FormArray([])
    })
  }

  /**
* Close modal
*/
  closemodal() {
    this.modalService.dismissAll();
  }

  toggleFieldTextType() {
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
    let idRecurso = this.dataApi.idRecurso;
    let modulos = this.moduleForm.value['modulos'];

    for (let index = 0; index < modulos.length; index++) {
      modulos[index].idRecurso = idRecurso;
    }

    Swal.fire({
      title: "¿Deseas guardar los cambios?",
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: "Guardar",
      denyButtonText: `No guardar`
    }).then((result) => {
      if (result.isConfirmed) {
        this.api.createData('Modules', modulos).subscribe((data) => {
          if (data.isSuccess) {
            Swal.fire(data.message, "", "success").then((result) => {
              if(result.isConfirmed) this.closemodal();
              this.route.navigate(['/product'])
            });
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

  signup() { }
  
  // Delete Item
  removeItem(index: any) {
    (this.moduleForm.get('modulos') as UntypedFormArray).removeAt(index);
  }

  getItemFormControls(): AbstractControl[] {
    return (<UntypedFormArray>this.moduleForm.get('modulos')).controls
  }

  // Add Item
  addItem(): void {
    (this.moduleForm.controls['modulos'] as FormArray).push(
      new FormGroup({
        idRecurso: new FormControl(''),
        nombreModulo: new FormControl('', Validators.required),
        urlModulo: new FormControl('', Validators.required)
      })
    );
  }

}

