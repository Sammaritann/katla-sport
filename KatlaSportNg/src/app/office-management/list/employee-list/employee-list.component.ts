import { Component, OnInit } from '@angular/core';
import { Employee } from 'app/office-management/models/emploee';
import { EmployeeService } from 'app/office-management/services/emploee-service.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  staf:Employee[];
  officeId:number;

  constructor(
    private employeeService:EmployeeService,
    private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.officeId = p['id'];
      this.employeeService.getOfficeStaf(this.officeId).subscribe(s => this.staf = s);})
  }

  onDelete(officeId: number) {
    this.employeeService.deleteEmployee(officeId);
  }

}
