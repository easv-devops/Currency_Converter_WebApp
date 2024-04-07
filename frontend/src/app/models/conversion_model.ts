export class ConversionHistory {
  id?: number;
  sourceCurrency?: string;
  targetCurrency?: string;
  amount?: number;
  convertedAmount?: number;
  timestamp?: Date;

  constructor(init?: Partial<ConversionHistory>) {
    Object.assign(this, init);
    if (init && init.timestamp) {
      this.timestamp = new Date(init.timestamp);
    }
  }
}

export class ResponseDto<T> {
  responseData?: T;
  messageToClient?: string;
}
