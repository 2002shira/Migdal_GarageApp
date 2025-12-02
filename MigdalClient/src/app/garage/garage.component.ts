import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { GarageService } from '../shared/services/garage.service';
import { Garage } from '../models/garage.model';
import { HeaderComponent } from '../shared/components/header/header.component';

@Component({
  selector: 'app-garage',
  standalone: true,
  imports: [CommonModule, FormsModule, MatTableModule, MatFormFieldModule, MatSelectModule, MatButtonModule, MatCardModule, MatToolbarModule, MatIconModule, MatInputModule, MatProgressSpinnerModule, HeaderComponent],
  templateUrl: './garage.component.html',
  styleUrls: ['./garage.component.scss']
})
export class GarageComponent implements OnInit {
  garages: Garage[] = [];
  displayedColumns: string[] = ['shem_mosah', 'yishuv', 'mikud', 'telephone', 'miktzoa'];
  selectedGarages: number[] = [];
  filterOptions: Garage[] = [];

  // filter text for table name search
  filterText = '';

  // local loading state used when reloading data from the DB
  isLoading = false;

  constructor(private garageService: GarageService) {}

  ngOnInit(): void {
    this.garageService.getAll({}).subscribe((data) => {
      this.filterOptions = (data || []).map(item => this.normalize(item));
      console.debug('[GarageComponent] filterOptions loaded:', this.filterOptions);
    });

    this.garageService.loadAllFromDb({}).subscribe((data) => {
      this.garages = (data || []).map(item => this.normalize(item));
    });
  }

  private normalize(item: any): Garage {
    return {
      _id: item._id ?? item.id ?? 0,
      mispar_mosah: item.mispar_mosah ?? item.misparMosach ?? 0,
      shem_mosah: item.shem_mosah ?? item.shemMosach ?? '',
      cod_sug_mosah: item.cod_sug_mosah ?? item.codSugMosach ?? 0,
      sug_mosah: item.sug_mosach ?? item.sugMosach ?? '',
      ktovet: item.ktovet ?? item.ktovet ?? '',
      yishuv: item.yishuv ?? item.yishuv ?? '',
      telephone: item.telephone ?? item.telephone ?? '',
      mikud: item.mikud ?? item.mikud ?? 0,
      cod_miktzoa: item.cod_miktzoa ?? item.codMiktzoa ?? 0,
      miktzoa: item.miktzoa ?? item.miktzoa ?? '',
      menahel_miktzoa: item.menahel_miktzoa ?? item.menahelMiktzoa ?? '',
      rasham_havarot: item.rasham_havarot ?? item.rashamHavarot ?? 0,
      TESTIME: item.TESTIME ?? item.testime ?? ''
    } as Garage;
  }

  getColumnLabel(col: string): string {
    switch (col) {
      case 'shem_mosah': return 'שם מוסך';
      case 'yishuv': return 'יישוב';
      case 'mikud': return 'מיקוד';
      case 'telephone': return 'טלפון';
      case 'miktzoa': return 'מקצוע';
      default: return col;
    }
  }

  // return the garages filtered by name (shem_mosah)
  get displayedGarages(): Garage[] {
    const txt = (this.filterText || '').trim().toLowerCase();
    if (!txt) return this.garages;
    return this.garages.filter(g => (g.shem_mosah || '').toLowerCase().includes(txt));
  }

  clearAll(): void {
    // UX: clear selection and filter immediately, then reload fresh data from DB
    this.selectedGarages = [];
    this.filterText = '';

    this.isLoading = true;
    this.garageService.loadAllFromDb({}).subscribe({
      next: (data) => {
        this.garages = (data || []).map(item => this.normalize(item));
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Failed to reload garages from DB', err);
        // leave garages untouched on error or optionally clear — here we keep current list
        this.isLoading = false;
      }
    });
  }

  addSelectedGarages(): void {
    if (!this.selectedGarages || this.selectedGarages.length === 0) {
      console.debug('no garages selected');
      return;
    }

    const toAdd = this.filterOptions.filter(f => this.selectedGarages.includes(f._id));

    const existingKeys = new Set(this.garages.map(g => `${g.mispar_mosah}::${g.cod_miktzoa}`));
    const newOnes = toAdd.filter(g => {
      const key = `${g.mispar_mosah}::${g.cod_miktzoa}`;
      return !existingKeys.has(key);
    });

    if (newOnes.length === 0) {
      console.debug('no new garages to add');
      return;
    }

    const payloadList = newOnes.map(g => ({
      misparMosach: g.mispar_mosah,
      shemMosach: g.shem_mosah,
      codSugMosach: g.cod_sug_mosah,
      sugMosach: g.sug_mosah,
      ktovet: g.ktovet,
      yishuv: g.yishuv,
      telephone: g.telephone,
      mikud: g.mikud,
      codMiktzoa: g.cod_miktzoa,
      miktzoa: g.miktzoa,
      menahelMiktzoa: g.menahel_miktzoa,
      rashamHavarot: g.rasham_havarot,
      testime: g.TESTIME
    }));

    this.garageService.addGaragesRequest(payloadList).subscribe({
      next: (res) => {
        console.debug('add response', res);
        this.garages = [...this.garages, ...newOnes];
        this.selectedGarages = [];
      },
      error: (err) => console.error('add failed', err)
    });
  }

  isExisting(option: Garage): boolean {
    if (!option) return false;
    return this.garages.some(g => g.mispar_mosah === option.mispar_mosah && g.cod_miktzoa === option.cod_miktzoa);
  }

  get duplicateSelectedCount(): number {
    if (!this.selectedGarages || !this.filterOptions) return 0;
    const selectedSet = new Set(this.selectedGarages);
    return this.filterOptions.filter(o => selectedSet.has(o._id) && this.isExisting(o)).length;
  }
}
