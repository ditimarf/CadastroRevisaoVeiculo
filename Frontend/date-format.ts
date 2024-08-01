import { NativeDateAdapter, MAT_DATE_FORMATS, DateAdapter, MatDateFormats } from '@angular/material/core';
import { Injectable } from '@angular/core';

// Defina os formatos de data personalizados
export const MY_DATE_FORMATS: MatDateFormats = {
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'DD/MM/YYYY',
    monthYearA11yLabel: 'MMMM YYYY',
  },
  parse: {
    dateInput: 'DD/MM/YYYY',
  },
};

@Injectable()
export class MyDateAdapter extends NativeDateAdapter {
  override format(date: Date, displayFormat: Object): string {
    if (displayFormat === 'input') {
      return this.formatDate(date, 'dd/MM/yyyy');
    }
    return super.format(date, displayFormat);
  }

  private formatDate(date: Date, format: string): string {
    const day = this.pad(date.getDate());
    const month = this.pad(date.getMonth() + 1); // Meses são baseados em 0
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
  }

  private pad(n: number): string {
    return n < 10 ? '0' + n : n.toString();
  }
}
