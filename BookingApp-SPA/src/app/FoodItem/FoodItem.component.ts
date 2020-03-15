import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component( {
  selector: 'app-food-item',
  templateUrl: './FoodItem.component.html',
  styleUrls: ['./FoodItem.component.css']
})

export class FoodItemComponent implements OnInit {
  FoodItems: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getFoodItems();
  }



  getFoodItems() {
    this.http.get('http://localhost:5000/api/FoodItem').subscribe(response => {
      this.FoodItems = response;
    }, error => {
      console.log(error);
    });
  }

}
