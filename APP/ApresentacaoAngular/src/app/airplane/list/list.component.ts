import { AirplaneModel } from './../airplane.model';
import { AirplaneService } from './../../airplane.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';



@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})



export class ListComponent implements OnInit {

  public Airplanes: Array<AirplaneModel> = new Array<AirplaneModel>();

  constructor(private airplaneService: AirplaneService, private router: Router) { }

  ngOnInit() {
    this.airplaneService.getAll().subscribe(res => {
      if (res.status === 1) {
        this.Airplanes  = res.value.airplanes;
      } else {
        alert('Error');
      }
    });
  }

  delete(id: number) {
    this.airplaneService.deleteAirplane(id).subscribe(res => {
      if (res.status === 1) {
        this.router.navigate(['/airplanes']);
      }
    });
  }
  search(id: number) {
    this.router.navigate([`/airplanes/details/${id}`]);
  }
}
