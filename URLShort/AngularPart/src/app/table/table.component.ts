import { Component, OnInit } from '@angular/core';
import {PreloadService} from '../core/services/preload.service';
import {TableModel} from './table.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  model: TableModel[];
  constructor(private preloadService: PreloadService<WeatherModel[]>) { }

  ngOnInit() {
    this.model = this.preloadService.data;
  }

}
