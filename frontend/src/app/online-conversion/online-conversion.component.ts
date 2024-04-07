import { Component, OnInit } from '@angular/core';
import { ConversionService } from '../service/conversion_service';
import { ConversionHistory } from '../models/conversion_model';

@Component({
  selector: 'app-online-conversion',
  templateUrl: './online-conversion.component.html',
  styleUrl: './online-conversion.component.css'
})
export class OnlineConversionComponent  implements OnInit {
  selectedSourceCurrency: string = '';
  selectedTargetCurrency: string = '';
  amount: number = 0;
  convertedAmount: number | undefined;
  conversionHistory: ConversionHistory[] = [];

  constructor(public conversionService: ConversionService) {
  }

  ngOnInit(): void {
    this.loadConversionHistory();
  }

  async loadConversionHistory() {
    try {
      const response = await this.conversionService.getConversionHistory();
      if (response.responseData !== undefined) {
        this.conversionHistory = response.responseData;
        console.log('Conversion history:', this.conversionHistory);
      } else {
        throw new Error('Conversion history is undefined');
      }
    } catch (error) {
      console.error('Error loading conversion history:', error);
    }
  }

  async convertCurrency() {
    try {
      this.convertedAmount = await this.conversionService.convertCurrency(
        this.amount,
        this.selectedSourceCurrency,
        this.selectedTargetCurrency
      );
    } catch (error) {
      console.error('Error converting currency:', error);
    }
  }

  async updateTableAndClearTextArea() {
    try {
      await this.loadConversionHistory();
      this.amount = 0;
      this.convertedAmount = 0;
      this.selectedSourceCurrency = '';
      this.selectedTargetCurrency = '';
    } catch (error) {
      console.error('Error updating table and clearing text area:', error);
    }
  }
}
