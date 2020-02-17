import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'app/office-management/models/emploee';
import { EmployeeService } from 'app/office-management/services/emploee-service.service';

@Component({
  selector: 'app-emploee',
  templateUrl: './emploee.component.html',
  styleUrls: ['./emploee.component.css']
})
export class EmploeeComponent implements OnInit {

  employee = new Employee(0,"","","",0,null);
  fileInput = new File(['a','b','c'],"");
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) { }

  ngOnInit() {    this.route.params.subscribe(p => { 
    if (p['id'] === undefined) return;
    this.employeeService.getEmployee(p['id']).subscribe(h => this.employee = h);
    this.existed = true;
  });
  }

  navigateToStaf() {
    this.router.navigate(['/staf']);
  }

  onCancel() {
    this.navigateToStaf();
  }
  
  onSubmit() {
    if(this.existed)
    {
      this.employeeService.updateEmployee(this.employee).subscribe(p=>this.navigateToStaf());
    }
    else
    {
      this.employeeService.addEmployee(this.employee).subscribe(p=>this.navigateToStaf());
    }
  }

  onDelete() 
  {
    if(this.existed)
    {
      this.employeeService.deleteEmployee(this.employee.id).subscribe(p=> this.navigateToStaf());
    }
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
