import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  isNavbarActive = true;
  constructor() { 
    console.log('shared service')
  }
}
