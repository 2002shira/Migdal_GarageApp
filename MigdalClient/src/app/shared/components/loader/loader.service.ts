import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class LoaderService {
  private _count = 0;
  private _nextId = 0;
  private _timers = new Map<number, any>();
  private _loading = new BehaviorSubject<boolean>(false);
  readonly loading$ = this._loading.asObservable();

  // backward-compatible simple API
  show(): void {
    this._loading.next(true);
  }

  hide(): void {
    this._loading.next(false);
  }

  // token-based API for interceptors
  requestStarted(): number {
    const id = ++this._nextId;
    this._count++;
    if (this._count > 0) {
      this._loading.next(true);
    }
    // safety timeout to avoid stuck loader
    const timer = setTimeout(() => {
      this.requestEnded(id);
    }, 30000);
    this._timers.set(id, timer);
    return id;
  }

  requestEnded(id?: number): void {
    if (id && this._timers.has(id)) {
      clearTimeout(this._timers.get(id));
      this._timers.delete(id);
    }
    if (this._count > 0) {
      this._count--;
    }
    if (this._count === 0) {
      this._loading.next(false);
    }
  }

  reset(): void {
    this._timers.forEach(t => clearTimeout(t));
    this._timers.clear();
    this._count = 0;
    this._loading.next(false);
  }
}
