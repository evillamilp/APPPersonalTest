import { NgModule } from '@angular/core';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import {PersonalTestComponent} from './personal-test.component'
import { FormsModule,ReactiveFormsModule }   from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table' 
import { MatButtonModule } from '@angular/material/button'

@NgModule({
    declarations: [PersonalTestComponent],
    imports: [
      CommonModule,
      FormsModule,
      ReactiveFormsModule,
      NgxMaskDirective, 
      MatFormFieldModule,
      MatInputModule,
      MatTableModule,
      MatButtonModule,
      NgxMaskPipe,
    ],
    providers: [ provideNgxMask() ],
    exports:[
        PersonalTestComponent,
        CommonModule,
        FormsModule,
        MatFormFieldModule,
        MatInputModule,
        ReactiveFormsModule,
        MatTableModule
    ]
  })
  export class PersonalTestModule{}