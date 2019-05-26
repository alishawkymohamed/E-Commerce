import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class FileService {

    constructor() { }

    getBase64StringFromFile(file): Observable<string> {
        return from(new Promise((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsBinaryString(file);
            reader.onload = () => resolve(btoa(reader.result.toString()));
            reader.onerror = error => reject(error);
        }));
    }
}