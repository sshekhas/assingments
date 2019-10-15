import { Component, OnInit } from '@angular/core';
import { listOfProfiles } from "./../data";
import { DataService } from "./../data.service";
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
itm:listOfProfiles;
indexposition:number;
updatediv= false;
listtoshow:listOfProfiles[];
  constructor(private displayobj:DataService) { 
    this.listtoshow=this.displayobj.getlist()
  }
edit(index:number){
  this.updatediv=true;
  this.itm=this.listtoshow[index];
  this.itm.modifieddate=new Date();
  this.displayobj.update(this.itm,this.indexposition)
}
deletethis(index:number){
  this.displayobj.delete(index)
}
  ngOnInit() {
  }

}
