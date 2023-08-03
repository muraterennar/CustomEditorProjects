import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlogDetailsComponent } from './blog-details.component';



@NgModule({
  declarations: [
    BlogDetailsComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    BlogDetailsComponent
  ]
})
export class BlogDetailsModule { }
