import { Component, OnInit } from '@angular/core';
import { ItemService } from 'app/office-management/services/item.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Item } from 'app/office-management/models/item';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {

  items:Item[];
  parentId =0;
  constructor(private itemService:ItemService,
    private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit() {
         this.getItems();
  }

  getItems()
  {
    this.route.params.subscribe(p => {
      if((p['id'] !== undefined))
      this.itemService.getOfficeItems(p['id']).subscribe(i => this.items = i);
      if(p['descendantId'] !== undefined)
      { 
       this.parentId = p['descendantId'];
       this.itemService.getDescendantItems(p['descendantId']).subscribe(i => this.items = i);
      }
    })
  }

  onDelete(officeId: number) {
    this.itemService.deleteItem(officeId);
  }

}
