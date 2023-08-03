import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeModule } from './home/home.module';
import { BlogDetailsModule } from './blog-details/blog-details.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HomeModule,
    BlogDetailsModule
  ],
  exports: [HomeModule, BlogDetailsModule]
})
export class UIModule { }
