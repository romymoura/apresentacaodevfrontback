import { AirplaneModel } from './../airplane.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AirplaneService } from './../../airplane.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {
  AirplaneModel: AirplaneModel;
  constructor(private airplaneService: AirplaneService, private activeRoute: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    const routeParams = this.activeRoute.snapshot.params;
    this.AirplaneModel = new AirplaneModel(routeParams.id, '', 0, '');

    this.airplaneService.getAirplane(this.AirplaneModel).subscribe(res => {
      if (res.status === 1) {
        this.AirplaneModel = res.value.airplane as AirplaneModel;
      }
    });
  }

  delete(id: number) {
    this.airplaneService.deleteAirplane(id).subscribe(res => {
      if (res.status === 1) {
        this.router.navigate([`/airplanes`]);
      }
    });
  }
}
