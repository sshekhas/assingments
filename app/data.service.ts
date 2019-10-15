import { Injectable } from '@angular/core';
import { listOfProfiles } from "./data";
@Injectable({
  providedIn: 'root'
})
export class DataService {
listitems:listOfProfiles[]=[
{department:1, name:'Engineering',groupname:'research and deveploment',modifieddate: new Date()},
{department:2, name:'Tool Desidn',groupname:'research and deveploment',modifieddate: new Date()},
{department:3, name:'Sales',groupname:'sales and marketing',modifieddate: new Date()},
{department:4, name:'Marketing',groupname:'sales and marketing',modifieddate: new Date()},
{department:5, name:'Purchasing',groupname:'inventory Managment',modifieddate: new Date()},
]
  constructor() { }
  getlist(){
    return this.listitems
  }
  save(emp:listOfProfiles)
  {
    this.listitems.push(emp);
  }
  update(emp:listOfProfiles,index:number)
  {
    
     this.listitems[index]=emp;
      }
  delete(index :number)
  {
    this.listitems.splice(index,1);
  }
}
