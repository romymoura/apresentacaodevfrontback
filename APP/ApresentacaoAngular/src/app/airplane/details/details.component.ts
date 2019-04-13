import { AirplaneService } from './../../airplane.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AirplaneModel } from './../airplane.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  AirplaneModel: AirplaneModel;
  constructor(private airplaneService: AirplaneService, private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    const routeParams = this.activeRoute.snapshot.params;
    this.AirplaneModel = new AirplaneModel(routeParams.id, '', 0, '');

    this.airplaneService.getAirplane(this.AirplaneModel).subscribe(res => {
      if (res.status === 1) {
        this.AirplaneModel = res.value.airplane as AirplaneModel;
      }
    });

  }

}
