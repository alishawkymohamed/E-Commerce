import { Component, ViewEncapsulation } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [ './app.component.scss' ],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'eCommerce';
  lang = 'ar';
  constructor (private translate: TranslateService) {
    // this language will be used as a fallback when a translation isn't found in the current language
    translate.setDefaultLang('ar');
    this.changeLanguage(this.lang);

  }

  changeLanguage(lang) {
    // the lang to use, if the lang isn't available, it will use the current loader to get them
    this.translate.use(lang);
  }
}
