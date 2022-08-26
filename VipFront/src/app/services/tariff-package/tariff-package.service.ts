import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TariffPackage } from 'src/app/models/tariff-package/tariff-package.model';

@Injectable({
  providedIn: 'root'
})
export class TariffPackageService {

  constructor(private http: HttpClient) { }

  baseUrl = 'https://localhost:44315/api/'

  url = {
    tariffPackage: this.baseUrl + 'TariffPackages',
    packageTypes: this.baseUrl + 'PackageTypes',

  }

  getTariffPackages(): Observable<TariffPackage[]> {
    // console.log(this.url.tariffPackage);
    return this.http.get<TariffPackage[]>(this.url.tariffPackage);
  }

  getPackageTypes(): Observable<TariffPackage["packageType"][]> {
    return this.http.get<TariffPackage["packageType"][]>(this.url.packageTypes);
  }

  saveTariffPackage(tariffPackage: TariffPackage) {
    return this.http.post<any>(this.url.tariffPackage, tariffPackage);
  }

  deleteTariffPackage(tariffPackage: TariffPackage){
    return this.http.delete<any>(this.url.tariffPackage + `/${tariffPackage.tariffPackageId}`);
  }

  updateTariffPackage(tariffPackage: TariffPackage){
    return this.http.put<any>(this.url.tariffPackage, tariffPackage);
  }
}
