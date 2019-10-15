import { Component, OnInit } from '@angular/core';
import { DataService } from "./../data.service";
import { listOfProfiles } from "./../data";
@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
 itm= new listOfProfiles();
  constructor(private formObj:DataService) { }

  ngOnInit() {
  }
saveToList(){
  this.itm.modifieddate=new Date()
  this.formObj.save(this.itm)
}
}
