import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {environment} from "../environments/environment";
import {ConversionHistory, ResponseDto} from "../models/conversion_model";
import {firstValueFrom} from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class ConversionService {
  currencies: string[] = ["USD", "EUR", "GBP", "JPY", "AUD"];

  constructor(private http: HttpClient) {
  }


  async convertCurrency(amount: number, fromCurrency: string, toCurrency: string): Promise<number> {
    try {
      const result = await this.http.get<number>(
        `${environment.BASE_URL}/money?amount=${amount}&fromCurrency=${fromCurrency}&toCurrency=${toCurrency}`
      ).toPromise();

      if (result !== undefined) {
        return result;
      } else {
        throw new Error('Result is undefined');
      }
    } catch (error) {
      throw error;
    }
  }


  async getConversionHistory(): Promise<ResponseDto<ConversionHistory[]>> {
    try {
      const history: any = await firstValueFrom(
        this.http.get<ResponseDto<ConversionHistory[]>>(`${environment.BASE_URL}/history`)
      );

      if (history !== undefined) {
        return history;
      } else {
        throw new Error('History is undefined');
      }
    } catch (error) {
      throw error;
    }
  }
}
