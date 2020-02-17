import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from 'app/main-page/main-page.component';
import { HiveFormComponent } from './hive-management/forms/hive-form.component';
import { HiveSectionFormComponent } from './hive-management/forms/hive-section-form.component';
import { HiveListComponent } from './hive-management/lists/hive-list.component';
import { HiveSectionListComponent } from './hive-management/lists/hive-section-list.component';
import { ProductCategoryFormComponent } from './product-management/forms/product-category-form.component';
import { ProductFormComponent } from './product-management/forms/product-form.component';
import { ProductCategoryListComponent } from './product-management/lists/product-category-list.component';
import { ProductCategoryProductListComponent } from './product-management/lists/product-category-product-list.component';
import { ProductListComponent } from './product-management/lists/product-list.component';
import { OfficeListComponent } from './office-management/list/office-list/office-list.component';
import { EmploeeComponent } from './office-management/forms/emploee/emploee.component';
import { OfficeComponent } from './office-management/forms/office/office.component';

const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainPageComponent },
  { path: 'categories', component: ProductCategoryListComponent },
  { path: 'category', component: ProductCategoryFormComponent },
  { path: 'category/:id', component: ProductCategoryFormComponent },
  { path: 'category/:id/products', component: ProductCategoryProductListComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'product/:id', component: ProductFormComponent },
  { path: 'category/:categoryId/product/:id', component: ProductFormComponent },
  { path: 'hives', component: HiveListComponent },
  { path: 'hive', component: HiveFormComponent },
  { path: 'hive/:id', component: HiveFormComponent },
  { path: 'hive/:id/sections', component: HiveSectionListComponent },
  { path: 'section/:id', component: HiveSectionFormComponent },
  { path: 'offices',component:OfficeListComponent},
  { path: 'office',component:OfficeComponent},
  { path: 'office/:id',component:OfficeComponent},
  { path: 'staff',component:EmploeeComponent},
  { path: 'staff/:id', component:EmploeeComponent},
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
