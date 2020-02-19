import { Component, OnInit } from '@angular/core';
import { ItemService } from 'app/office-management/services/item.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from 'app/office-management/models/item';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  item = new Item(0,"",1);
  parentId:number;
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private itemService: ItemService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => { 
      if(p['parentId'] !== undefined) this.parentId = p['parentId'];
      if (p['id'] === undefined) return;
      this.itemService.getItem(p['id']).subscribe(h => this.item = h);
      this.existed = true;});
  }


  navigateToOffice() {
    this.router.navigate([`/office`]);
  }

  onCancel() {
    this.navigateToOffice();
  }
  
  onSubmit() {
    if(this.existed)
    {
      this.itemService.updateItem(this.item).subscribe(p=>this.navigateToOffice());
    }
    else
    {
      if(this.parentId === undefined)
      {
       this.itemService.addItem(this.item).subscribe(p=>this.navigateToOffice());
      }
      else{
        this.itemService.addChildItem(this.item,this.parentId).subscribe(p=>this.navigateToOffice());
      }
    }
  }

  onDelete() 
  {
    if(this.existed)
    {
      this.itemService.deleteItem(this.item.id).subscribe(p=> this.navigateToOffice());
    }
  }


}
