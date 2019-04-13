import { AirplaneModel } from './../airplane.model';
import { AirplaneService } from './../../airplane.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
  providers: [AirplaneModel]
})
export class DetailsComponent implements OnInit {
  public AirplaneModel: AirplaneModel;
  constructor(private airplaneService: AirplaneService, private activeRoute: ActivatedRoute) { }
  ngOnInit() {
    const routeParams = this.activeRoute.snapshot.params;
    alert(routeParams.id);
    alert(this.AirplaneModel.id);
    alert(routeParams.id);
    alert('1');
    this.airplaneService.getAirplane(this.AirplaneModel).subscribe(res => {
      if (res.status === 1) {
        this.AirplaneModel = res.value.airplane as AirplaneModel;
      }
    });
  }
}
