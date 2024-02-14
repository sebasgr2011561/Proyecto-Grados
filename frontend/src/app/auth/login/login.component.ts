import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/auth/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  get email(){
    return this.loginForm.controls.email;
  }

  get password(){
    return this.loginForm.controls.password;
  }

  loginForm = this.formBuilder.group({
    email: ['sebas@gmail.com',[Validators.required,Validators.email]],
    password: ['', Validators.required],
  });


  // FormBuilder se encarga del manejo de los formularios reactivos
  constructor(private formBuilder: FormBuilder, private router: Router, private Loginservice: LoginService) {}

  ngOnInit(): void{
  }
  // Metodo al momento de dar click al iniciar el login
  login(){
    if(this.loginForm.valid){

      this.Loginservice.login(this.loginForm.value);
      //en esta linea de codigo se resetean los datos
      this.router.navigateByUrl('/inicio');
      this.loginForm.reset();
    }
    else{
        // Metodo para resaltar el formulario con los datos incorrestos y correctos
      this.loginForm.markAllAsTouched();
      alert("error al ingresar los datos")
    }
  }

}
