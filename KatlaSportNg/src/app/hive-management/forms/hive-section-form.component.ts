import { Component, OnInit } from '@angular/core';
import { HiveSection } from '../models/hive-section';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveService } from '../services/hive.service';
import { HiveSectionService } from '../services/hive-section.service';

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {

  hiveSection = new HiveSection(0,"","",false,0,"");
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() { 
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.hiveSectionService.getHiveSection(p['id']).subscribe(h => this.hiveSection = h);
      this.existed = true;});
  }

  navigateToSections() {
    this.router.navigate([`/hive/${this.hiveSection.storeHiveId}/sections`]);
  }

  onCancel() {
    this.navigateToSections();
  }
  
  onSubmit() {
    if(this.existed)
    {
      this.hiveSectionService.updateHiveSection(this.hiveSection).subscribe(p=>this.navigateToSections());
    }
    else
    {
      this.hiveSectionService.addHiveSection(this.hiveSection).subscribe(p=>this.navigateToSections());
    }
  }

  onDelete() 
  {
    if(this.existed)
    {
      this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id,true).subscribe(p=> this.navigateToSections());
    }
  }

  onUndelete() 
  {
    if(this.existed)
    {
      this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id,false).subscribe(p=>this.navigateToSections());
    }
  }

  onPurge() 
  {
    if(this.existed)
    {
      this.hiveSectionService.deleteHiveSection(this.hiveSection.id).subscribe(p=>this.navigateToSections());
    }
  }
}
