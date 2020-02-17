import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {Employee} from '../models/emploee'
import {EmployeeService} from '../services/emploee-service.service'
import { createOfflineCompileUrlResolver } from '@angular/compiler';
import { DebugContext } from '@angular/core/src/view';
import { StringDecoder } from 'string_decoder';

@Component({
  selector: 'app-emploee',
  templateUrl: './emploee.component.html',
  styleUrls: ['./emploee.component.css']
})
export class EmploeeComponent implements OnInit {

  employee = new Employee(0,"","","",0,null);
  fileInput = new File(['a','b','c'],"");

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) { }

  ngOnInit() {    this.route.params.subscribe(p => { 
    if (p['id'] === undefined) return;
    this.employeeService.getEmployee(p['id']).subscribe(h => this.employee = h);
  });
  }

  onSubmit() {
     console.log(this.employee.avatar);
      this.employeeService.updateEmployee(this.employee).subscribe(p=>this.router.navigate(["/main"]));

  }

  onFileChange(event) {
    let reader = new FileReader();
    if(event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.employee.avatar = reader.result.toString().split(',')[1];
      };
    }
  }

}
