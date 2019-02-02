import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { TooltipModule } from 'primeng/tooltip';
import { SidebarModule } from 'primeng/sidebar';
import { TableModule } from 'primeng/table';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
@NgModule({
    exports: [
        CommonModule,
        TranslateModule,
        TooltipModule,
        SidebarModule,
        TableModule,
        AngularFontAwesomeModule
    ]
})
export class SharedModule { }