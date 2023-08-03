import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlogComponent } from './blog.component';
import { RouterModule } from '@angular/router';
import { DirectivesModule } from 'src/app/directives/directives.module';



@NgModule({
  declarations: [
    BlogComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: BlogComponent }
    ]),
    DirectivesModule
  ],
  exports: [
    BlogComponent
  ]
})
export class BlogModule { }
