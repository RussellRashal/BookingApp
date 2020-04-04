import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-blankpage',
  templateUrl: './BlankPage.component.html',
  styleUrls: ['./BlankPage.component.css']
})
export class BlankPageComponent implements OnInit {
  @Input() bookingFromHome: any;
  @Input() make: string;
  employee = [
    'Mr', 'Mrs', 'Shinglongfong'
  ];

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }


}

