import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConstanteService {
  readonly rutaURL = 'https://localhost:5001';
  constructor() { }
}
