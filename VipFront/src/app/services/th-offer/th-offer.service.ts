import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ThOffer } from '../../models/th-offer/th-offer.model';
import { OfferItem } from 'src/app/models/offer-item/offer-item.model';

@Injectable({
  providedIn: 'root'
})
export class ThOfferService {

  constructor(private http: HttpClient) {}

  baseUrl = 'https://localhost:44315/api/'

  url = {
    tHOffer: this.baseUrl + 'THOffers',
    employee: this.baseUrl + 'Employees',
    tHServiceRequest: this.baseUrl + 'THServiceRequests',
    offerItems: this.baseUrl + 'OfferItems',
    tHService: this.baseUrl + 'THServices',
    client: this.baseUrl + 'Clients'
  }
  activationDate: Date = new Date();
  tHServiceId: number = 0;

  getTHServiceId():number{
    return this.tHServiceId;
  }
  setTHServiceID(id: number){
    this.tHServiceId = id;
  }
  getActivationDate():Date{
    return this.activationDate;
  }
  setActivationDate(date: Date){
    this.activationDate = date;
  }

  
  getThOffers(): Observable<ThOffer[]>{
    return this.http.get<ThOffer[]>(this.url.tHOffer);
  }
  
  getEmployees(): Observable<ThOffer["employee"][]> {
    return this.http.get<ThOffer["employee"][]>(this.url.employee);
  }

  getClients(): Observable<ThOffer["thServiceRequest"]["client"][]>{
    return this.http.get<ThOffer["thServiceRequest"]["client"][]>(this.url.client);
  }

  getThServiceRequests(): Observable<ThOffer["thServiceRequest"][]> {
    //console.log("OVDE SAM");
    return this.http.get<ThOffer["thServiceRequest"][]>(this.url.tHServiceRequest);
  }

  getOfferItems(): Observable<ThOffer["offerItems"]>{
    return this.http.get<ThOffer["offerItems"]>(this.url.tHService);
  }

  getTHServices(): Observable<OfferItem["thService"][]>{
    return this.http.get<OfferItem["thService"][]>(this.url.tHService);
  }

  saveThOffer(tHOffer: ThOffer){
    return this.http.post<any>(this.url.tHOffer, tHOffer);
  }

  daletetHOffer(tHOffer: ThOffer){
    return this.http.delete<any>(this.url.tHOffer + `/${tHOffer.thOfferId}`);
  }

  daleteOfferItem(offerItem: OfferItem){
   // return this.http.delete<ThOffer["offerItems"]>(this.url.offerItems + `/${ThOffer.OfferItem.OfferItemId}`);
  }

  updateTHOffer(tHOffer: ThOffer){
    return this.http.put<any>(this.url.tHOffer, tHOffer);
  }
}
