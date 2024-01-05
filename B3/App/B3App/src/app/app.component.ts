import { Component } from '@angular/core';
import { CdbService } from './cdb.service';
import { Cdb } from './interface/cdb';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'B3App';

  constructor(private cdbService: CdbService) { }

  ngOnInit(): void {
  }

  test(): void {
    this.cdbService.getTest().subscribe((analiseResponse: Cdb) => {
      console.log(analiseResponse);
    });;
  }


}
