import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import {
  HttpClient,
  HttpClientModule,
  HTTP_INTERCEPTORS,
  HttpBackend
} from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { SharedModule } from './shared.module';
import {
  MessageService,
  DialogService,
  ConfirmationService
} from 'primeng/api';
import { CookieService } from 'ngx-cookie-service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './_guards/auth.guard';
import {
  SwaggerClient,
  API_BASE_URL
} from './_services/swagger/SwaggerClient.service';
import { environment } from 'src/environments/environment';
import { InterceptorService } from './_services/swagger/interceptor.service';

export function createTranslateLoader(handler: HttpBackend) {
  const http = new HttpClient(handler);
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [AppComponent, HeaderComponent, FooterComponent],
  imports: [
    SharedModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpBackend]
      }
    })
  ],
  providers: [
    ConfirmationService,
    MessageService,
    DialogService,
    SwaggerClient,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true
    },
    {
      provide: API_BASE_URL,
      useValue: environment.apiUrl
    },
    Title,
    AuthGuard,
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
