import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { NewOrderComponent } from './new-order/new-order.component';
import { RawMaterialsComponent } from './raw-materials/raw-materials.component';
import { ProductsComponent } from './products/products.component';

const routes: Routes = [
  { path: "home", component: AdminHomeComponent },
  { path: "suppliers", component: SuppliersComponent },
  { path: "neworder", component: NewOrderComponent },
  { path: "rawmaterials", component: RawMaterialsComponent },
  { path: "products", component: ProductsComponent },
  { path: "**", redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }


