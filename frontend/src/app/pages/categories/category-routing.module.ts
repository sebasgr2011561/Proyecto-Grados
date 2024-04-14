import { RouterModule, Routes } from "@angular/router";
import { CategoriesComponent } from "./categories/categories.component";
import { AddCategoriesComponent } from "./add-categories/add-categories.component";
import { NgModule } from "@angular/core";


const routes: Routes = [
    {
        path: 'categories', component: CategoriesComponent
    },
    {
        path: 'newCategory', component: AddCategoriesComponent
    },
    {
        path: 'editCategory/{id}', component: AddCategoriesComponent
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: []
})
export class CategoryRoutingModule { }