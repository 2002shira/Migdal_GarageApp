import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: true,
  template: `<header class="app-header"><h1>Migdal Garage</h1></header>`,
  styles: [`.app-header{padding:1rem;background:#fff;border-bottom:1px solid #eee}`]
})
export class HeaderComponent {}
