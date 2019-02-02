import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: [ './header.component.scss' ]
})
export class HeaderComponent implements OnInit {
  display = false;
  Language = 'ar';
  // it's important to name it with the 'Change' suffix
  @Output() LanguageChanged = new EventEmitter();
  constructor () { }

  ngOnInit() {
  }

  UpdateLanguage() {
    if (this.Language === 'ar') {
      this.Language = 'en';
    } else {
      this.Language = 'ar';
    }

    this.LanguageChanged.emit(this.Language);
  }
}
