import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TravelExpensesDTO } from '../travel-expenses';
import { TravelExpensesService } from '../traveal-expenses-service.service';
import { Location } from '@angular/common'; // Import Location module if not already imported


@Component({
  selector: 'app-expenses-detail',
  templateUrl: './expenses-detail.component.html',
  styleUrls: ['./expenses-detail.component.css']
})

export class ExpensesDetailComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private detailService: TravelExpensesService,
    private location: Location) { }

  ngOnInit(): void {
    this.getDetail();
  }

  getDetail(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.detailService.getDetail(id);
  }

}
