import { Component, OnInit } from '@angular/core';
import { RawMaterial } from '../../Models/raw-material';
import { RawMaterialsService } from '../../Services/raw-materials.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import * as $ from "jquery";
import { InventoryComponentBase } from '../../inventory-component';

@Component({
  selector: 'app-raw-materials',
  templateUrl: './raw-materials.component.html',
  styleUrls: ['./raw-materials.component.scss']
})
export class RawMaterialsComponent extends InventoryComponentBase
{

}
