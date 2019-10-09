import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Supplier } from '../Models/supplier';
import { Admin } from '../Models/admin';
import { RawMaterial } from '../Models/raw-material';

@Injectable({
  providedIn: 'root'
})
export class InventoryDataService implements InMemoryDbService
{
  constructor() { }

  createDb()
  {
    let admins = [
      new Admin(1, '101', 'Admin', 'admin@capgemini.com', 'manager')
    ];

    let suppliers = [
      new Supplier(1, "401476EE-0A3B-482E-BD5B-B94A32355959", "Scott", "9876543210", "scott@capgemini.com", "Scott123#", "10/3/2019", "10/4/2019"),
      new Supplier(2, "C628855C-FE7A-4D94-A1BB-167157D3F4EA", "Smith", "9988776655", "smith@capgemini.com", "Smith123#", "9/6/2019", "5/7/2019"),
      new Supplier(3, "6D68849C-8FA8-4049-A111-B431C76C6548", "Arun", "7781994834", "arun@capgemini.com", "Arun123#", "1/5/2017", "15/11/2018"),
      new Supplier(4, "53E8748F-61D6-494B-BF72-E18B27511EFA", "Jones", "6989493491", "jones@capgemini.com", "Jones123#", "2/7/2019", "12/1/2019")
    ];

    let rawMaterials = [
      new RawMaterial(1, "8A516843-A011-499F-83A4-B45C1841DB85", "MG", "Mango", 20, "12/10/2019", "12/10/2019"),
      new RawMaterial(2, "D0BC5995-A29F-4E7E-9878-C944CEE6C2C2", "PCH", "Peach", 30, "12/10/2019", "12/10/2019"),
      new RawMaterial(3, "6310B420-948D-4B44-981A-69609AA84196", "BAN", "Banana", 25, "12/10/2019", "12/10/2019"),
      new RawMaterial(4, "A1AB1C90-9C89-4A08-A892-A0074201E137", "CC", "Coconut", 30, "13/10/2019", "13/10/2019"),
    ];
    return { admins, suppliers, rawMaterials };
  }
}


