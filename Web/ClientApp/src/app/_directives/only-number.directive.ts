import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
    // tslint:disable-next-line: directive-selector
    selector: '[numeric]'
})
export class NumericDirective {

    // tslint:disable-next-line: no-input-rename
    @Input('numericType') numericType: string; // number | decimal

    private regex = {
        number: new RegExp(/^\d+$/),
        decimal: new RegExp(/^[0-9]+(\.[0-9]*){0,1}$/g)
    };

    private specialKeys = ['Backspace', 'Tab', 'End', 'Home', 'ArrowLeft', 'ArrowRight'];

    constructor(private el: ElementRef) {
    }

    @HostListener('keydown', ['$event'])
    onKeyDown(event: KeyboardEvent) {

        if (this.specialKeys.indexOf(event.key) !== -1) {
            return;
        }
        // Do not use event.keycode this is deprecated.
        // See: https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent/keyCode
        let current: string = this.el.nativeElement.value;
        let next: string = current.concat(event.key);
        if (next && !String(next).match(this.regex[this.numericType])) {
            event.preventDefault();
        }
    }
}