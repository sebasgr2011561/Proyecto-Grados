import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UntypedFormBuilder, Validators, UntypedFormGroup } from '@angular/forms';
import { SignmodalComponent } from '../signmodal/signmodal.component';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { cartdata } from 'src/app/pages/cart/data';
import { MenuItem } from './menu.model';
import { MENU1 } from './menu';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public isCollapsed = true;
  formData!: UntypedFormGroup;
  signupformData!: UntypedFormGroup;
  signupPassfield!: boolean;
  fieldTextType: any;
  submitted = false;
  signupsubmit = false;
  selectedLocation: any;
  term:any;
  menu: any;
  menuItems: MenuItem[] = [];

  constructor(public formBuilder: UntypedFormBuilder,
    private modalService: NgbModal,
    public translate: TranslateService,
    public router: Router) {
      translate.setDefaultLang('en');
  }

  ngOnInit(): void {

      this.menuItems = MENU1;

    // Validation
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

  // set location
  ChangeLocation(location: any) {
    this.selectedLocation = location
  }

  /**
  * Open modal
  */
  openModal() {
    // this.submitted = false;
    this.modalService.open(SignmodalComponent, { size: 'md', centered: true });
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
    if (this.formData.valid) {
      const message = this.formData.get('email')!.value;
      const pwd = this.formData.get('password')!.value;
      this.modalService.dismissAll();
    }
    this.submitted = true;
  }

  signup() {
    if (this.signupformData.valid) {
      const message = this.signupformData.get('email')!.value;
      const pwd = this.signupformData.get('password')!.value;
      this.modalService.dismissAll();
    }
    this.signupsubmit = true;
  }

  // tslint:disable-next-line: typedef
  windowScroll() {
    const navbar = document.querySelector('.navbar-sticky');
    if (document.body.scrollTop > 350 || document.documentElement.scrollTop > 350) {
      navbar?.classList.add('navbar-stuck');
      document.querySelector(".btn-scroll-top")?.classList.add('show');
    }
    else {
      navbar?.classList.remove('navbar-stuck');
      document.querySelector(".btn-scroll-top")?.classList.remove('show');
    }
  }

    // Menu Link Active
    updateActive(event: any) {
      this.activateParentDropdown(event.target);
    }

    // remove active items of two-column-menu
    activateParentDropdown(item: any) { // navbar-nav menu add active
      item.classList.add("active");
      let parentCollapseDiv = item.closest(".dropdown-menu");
      if (parentCollapseDiv) {
        parentCollapseDiv.parentElement.children[0].classList.add("active")
      }
      return false;
    }

    setmenuactive() {
      setTimeout(() => {
        const pathName = window.location.pathname;
        const ul = document.getElementById("navbar-nav");
        if (ul) {
          const items = Array.from(ul.querySelectorAll("a.sublink"));
          let activeItems = items.filter((x: any) => x.classList.contains("active"));
          let matchingMenuItem = items.find((x: any) => {
            return x.pathname === pathName;
          });
          this.activateParentDropdown(matchingMenuItem);
        }
      }, 0);
    }



}
