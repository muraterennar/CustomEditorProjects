import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomEditorServiceComponent } from './custom-editor-service.component';
import { DirectivesModule } from 'src/app/directives/directives.module';



@NgModule({
  declarations: [
    CustomEditorServiceComponent
  ],
  imports: [
    CommonModule,
    DirectivesModule
  ],
  exports: [
    CustomEditorServiceComponent
  ]
})
export class CustomEditorServiceModule { }
