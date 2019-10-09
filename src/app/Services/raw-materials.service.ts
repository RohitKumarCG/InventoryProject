import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RawMaterial } from '../Models/raw-material';

@Injectable({
  providedIn: 'root'
})

export class RawMaterialsService {
  constructor(private httpClient: HttpClient) {
  }

  AddRawMaterial(rawmaterial: RawMaterial): Observable<boolean>
  {
    rawmaterial.creationDateTime = new Date().toLocaleDateString();
    rawmaterial.lastModifiedDateTime = new Date().toLocaleDateString();
    rawmaterial.rawMaterialID = this.uuidv4();
    return this.httpClient.post<boolean>(`/api/rawMaterials`, rawmaterial);
  }

  UpdateRawMaterial(rawmaterial: RawMaterial): Observable<boolean>
  {
    rawmaterial.lastModifiedDateTime = new Date().toLocaleDateString();
    return this.httpClient.put<boolean>(`/api/rawMaterials`, rawmaterial);
  }

  DeleteRawMaterial(RawMaterialID: string, ID: number): Observable<boolean>
  {
    return this.httpClient.delete<boolean>(`/api/rawMaterials/${ID}`);
  }

  GetAllRawMaterials(): Observable<RawMaterial[]>
  {
    return this.httpClient.get<RawMaterial[]>(`/api/rawMaterials`);
  }

  GetRawMaterialByRawMaterialID(RawMaterialID: string): Observable<RawMaterial>
  {
    return this.httpClient.get<RawMaterial>(`/api/rawMaterials?rawMaterialID=${RawMaterialID}`);
  }

  GetRawMaterialByRawMaterialName(RawMaterialName: string): Observable<RawMaterial[]>
  {
    return this.httpClient.get<RawMaterial[]>(`/api/rawMaterials?rawMaterialName=${RawMaterialName}`);
  }

  GetRawMaterialByCode(Code: string): Observable<RawMaterial>
  {
    return this.httpClient.get<RawMaterial>(`/api/rawMaterials?rawMaterialCode=${Code}`);
  }

  uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}
