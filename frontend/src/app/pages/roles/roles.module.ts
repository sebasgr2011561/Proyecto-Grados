import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedModule } from "src/app/shared/shared.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbNavModule, NgbTooltipModule } from "@ng-bootstrap/ng-bootstrap";
import { NgxDropzoneModule } from "ngx-dropzone";
import { AddRolesComponent } from "./add-roles/add-roles.component";
import { RolesComponent } from "./roles/roles.component";
import { RoleRoutingModule } from "./roles-routing.module";

@NgModule({
    declarations: [
        AddRolesComponent,
        RolesComponent
    ],
    imports: [
        CommonModule,
        RoleRoutingModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule,
        NgbNavModule,
        NgbTooltipModule,
        NgxDropzoneModule
    ]
})
export class RoleModule { }