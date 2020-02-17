import { Component, OnInit } from '@angular/core';
import { OfficeService } from 'app/office-management/services/office.service';
import { Office } from 'app/office-management/models/office';

@Component({
  selector: 'app-office-list',
  templateUrl: './office-list.component.html',
  styleUrls: ['./office-list.component.css']
})
export class OfficeListComponent implements OnInit {

  offices:Office[];

  constructor(private officeService:OfficeService) { }

  ngOnInit() {
    this.getOffices();
  }

  getOffices() {
    this.officeService.getOffices().subscribe(o => this.offices = o);
  }

  onDelete(officeId: number) {
    this.officeService.deleteOffice(officeId);
  }

}
