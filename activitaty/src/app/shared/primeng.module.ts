import { NgModule } from '@angular/core';

import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { FieldsetModule } from 'primeng/fieldset';
import { TagModule } from 'primeng/tag';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import {ToastModule} from 'primeng/toast';

const primeNgComponents = [
  CardModule,
  ButtonModule,
  MenubarModule,
  FieldsetModule,
  TagModule,
  InputTextModule,
  InputTextareaModule,
  ToastModule,
];

@NgModule({
  exports: [primeNgComponents],
})
export class PrimengModule {}
