import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlogModule } from './blog/blog.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BlogModule
  ],
  exports:[BlogModule]
})
export class AdminComponentsModule { }
