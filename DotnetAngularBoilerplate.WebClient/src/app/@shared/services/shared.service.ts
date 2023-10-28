import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  isNavbarActive = false;
  constructor() { 
    console.log('shared service')
  }
}
