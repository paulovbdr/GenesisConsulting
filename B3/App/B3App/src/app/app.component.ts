import { Component } from '@angular/core';
import { CdbService } from './cdb.service';
import { CdbModel } from './interface/cdb-model';
import { CdbResultModel } from './interface/cdb-result-model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'B3App';

  constructor(private cdbService: CdbService) {
  }

  cdbModel: CdbModel = {};
  cdbResultModel: CdbResultModel = {};
  inputInvestmenTimeMonth: boolean = false;
  inputAmount: boolean = false;

  ngOnInit(): void {
  }

  calculateInvestment(): void {
    if (typeof this.cdbModel.investmenTimeMonth === 'number' && this.cdbModel?.investmenTimeMonth <= 1) {
      this.inputInvestmenTimeMonth = true;
      return;
    }

    if (typeof this.cdbModel.amount === 'number' && this.cdbModel?.amount <= 0.0) {
      this.inputAmount = true;
      return;
    }

    this.cdbService.calculateInvestment(this.cdbModel).subscribe((analiseResponse: CdbResultModel) => {
      console.log(analiseResponse);
      this.cdbResultModel = analiseResponse;
      console.log(this.cdbResultModel);
    });;
  }

  isEmptyObject(obj: any): boolean {
    return Object.keys(obj).length === 0;
  }


}
