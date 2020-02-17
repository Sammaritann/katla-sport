import { Component, OnInit } from '@angular/core';
import { Office } from 'app/office-management/models/office';
import { ActivatedRoute, Router } from '@angular/router';
import { OfficeService } from 'app/office-management/services/office.service';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrls: ['./office.component.css']
})
export class OfficeComponent implements OnInit {

  office = new Office(0,"","");
  existed = true;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private officeService: OfficeService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => { 
      if (p['id'] === undefined) return;
      this.officeService.getOffice(p['id']).subscribe(o => this.office = o);
      this.existed = true;
    })
  }

  navigateToOffices() {
    this.router.navigate(['/offices']);
  }

  onCancel() {
    this.navigateToOffices();
  }
  
  onSubmit() {
    if(this.existed)
    {
      this.officeService.updateOffice(this.office).subscribe(p=>this.navigateToOffices());
    }
    else
    {
      this.officeService.addOffice(this.office).subscribe(p=>this.navigateToOffices());
    }
  }

  onDelete() 
  {
    if(this.existed)
    {
      this.officeService.deleteOffice(this.office.officeId).subscribe(p=> this.navigateToOffices());
    }
  }


}
