import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { TooltipModule } from 'primeng/tooltip';
import { SidebarModule } from 'primeng/sidebar';
import { TableModule } from 'primeng/table';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ToastModule } from 'primeng/toast';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { NumericDirective } from './_directives/only-number.directive';
@NgModule({
  declarations: [NumericDirective],
  exports: [
    CommonModule,
    TranslateModule,
    TooltipModule,
    SidebarModule,
    TableModule,
    AngularFontAwesomeModule,
    ConfirmDialogModule,
    MessagesModule,
    MessageModule,
    RadioButtonModule,
    ToastModule,
    DynamicDialogModule,
    DropdownModule,
    NumericDirective
  ]
})
export class SharedModule { }
