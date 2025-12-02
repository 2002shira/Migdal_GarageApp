import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LoaderService } from './loader.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-loader',
  standalone: true,
  imports: [CommonModule, MatProgressSpinnerModule, AsyncPipe],
  template: `<div class="loader-overlay" *ngIf="loader.loading$ | async">
    <mat-progress-spinner mode="indeterminate" diameter="60"></mat-progress-spinner>
  </div>`,
  styles: [`.loader-overlay{position:fixed;inset:0;display:flex;align-items:center;justify-content:center;background:rgba(0,0,0,0.15);z-index:2000}`]
})
export class LoaderComponent {
  constructor(public loader: LoaderService) {}
}
