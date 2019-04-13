import { AirplaneModel } from './../airplane.model';
import { AirplaneService } from './../../airplane.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  public codeAirplane: string;
  public countPassagers: number;
  public dateRegister: string;

  constructor(private airplaneSrevice: AirplaneService, private router: Router) { }

  ngOnInit() {
  }

  onCreate() {
    this.airplaneSrevice.createAirplane(new AirplaneModel(0, this.codeAirplane, this.countPassagers, this.dateRegister)).subscribe(resp => {
      if (resp.status === 1) {
        this.router.navigate(['/airplanes']);
      }
    });
  }
}
