import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ThOffer } from '../models/th-offer/th-offer.model';
import { ThOfferService } from '../services/th-offer/th-offer.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogInsertOfferItemComponent } from '../dialog-insert-offer-item/dialog-insert-offer-item.component';
import { MatTableDataSource } from '@angular/material/table';
import { OfferItem } from '../models/offer-item/offer-item.model';
import * as _ from 'lodash';  
import { toNumber } from 'lodash';

@Component({
  selector: 'app-dialog-th-offer',
  templateUrl: './dialog-th-offer.component.html',
  styleUrls: ['./dialog-th-offer.component.scss'],
})
export class DialogThOfferComponent implements OnInit {

  displayedColumns: string[] = ['thService','activationDate','action'];
  dataSource = new MatTableDataSource<OfferItem>();

  ThOfferForm!: FormGroup;
  Employees!: ThOffer["employee"][];
  thServiceRequests!: ThOffer["thServiceRequest"][];
  offerItems!: ThOffer["offerItems"];                             
  selectedThServiceRequest!: ThOffer["thServiceRequest"]["thServiceRequestId"];
  selectedEmployee!: ThOffer["employee"]["employeeId"];
  Clients!: ThOffer["thServiceRequest"]["client"][];

  actionBtn1: string = "Sačuvaj";
  actionBtn2: string = "Dodaj stavku";
  counter: number = 0;
  list: ThOffer[] = [];
  thServices!: OfferItem["thService"][];

  constructor(private formBuilder: FormBuilder,
    private thOfferService: ThOfferService,
    @Inject(MAT_DIALOG_DATA) public editData: ThOffer,
    private dialogRef: MatDialogRef<DialogThOfferComponent>,
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {

    this.getTHServices();
    this.getOfferItems();
    this.getThServiceRequests();
    this.getEmployees();
    this.getClients();

    this.ThOfferForm = this.formBuilder.group({
      thServiceRequest: ['', Validators.required],
      employee: ['', Validators.required],
      offerDate: ['', Validators.required],
      confirmationDeadline: ['', Validators.required]
    })
    if(this.editData){
      
      this.ThOfferForm.controls['thServiceRequest'].setValue(this.editData.thServiceRequest.thServiceRequestId);
      this.ThOfferForm.controls['employee'].setValue(this.editData.employee.employeeId);
      this.ThOfferForm.controls['offerDate'].setValue(this.editData.offerDate);
      this.ThOfferForm.controls['confirmationDeadline'].setValue(this.editData.confirmationDeadline);
      this.offerItems = this.editData.offerItems;
      console.log("ovde sam");
      //console.log(this.editData)
      console.log(this.offerItems);
      console.log(this.offerItems[0].thService);
      this.dataSource = new MatTableDataSource(this.offerItems);
    }
  }

  getClients(){
    this.thOfferService.getClients().subscribe(resp => {
      this.Clients = resp;
    })
  }

  getEmployees() {
    this.thOfferService.getEmployees().subscribe(resp => {
      this.Employees = resp;
    })
  }

  getThServiceRequests() {
    this.thOfferService.getThServiceRequests().subscribe(resp => {
      this.thServiceRequests = resp;
      // console.log(resp);
    })
  }

  getOfferItems() {
    this.thOfferService.getOfferItems().subscribe(resp => {
      this.offerItems = resp;
    })
  }

  getTHServices() {
    this.thOfferService.getTHServices().subscribe(resp => {
      this.thServices = resp;
    })
  }

  editTHOfferItem(offerItem: OfferItem, index: number){
   
    this.dialog.open(DialogInsertOfferItemComponent, {
      width: '30%',
      data: offerItem
    }).afterClosed().subscribe(value => {
      let data = this.dataSource.data;
     // console.log( this.offerItems.filter(thService => thService.thServiceId === this.thOfferService.getTHServiceId()));
      
      data[index].thServiceId = this.thOfferService.getTHServiceId();
      data[index].activationDate = this.thOfferService.getActivationDate();
      data[index].thService = this.thServices.filter(thService => thService.thServiceId === this.thOfferService.getTHServiceId())[0]; 
      data[index].thService.serviceType.description = "jebi se";

      this.dataSource = new MatTableDataSource(data);
      
    });
  }

  deleteTHOfferItem(offerItem: OfferItem, index: number){
  
    const data = this.dataSource.data;
    data.splice(index,1);
    this.dataSource = new MatTableDataSource(data);
  }

  selectThServiceRequests(tHServiceRequest: ThOffer["thServiceRequest"]) {
    this.selectedThServiceRequest = tHServiceRequest.thServiceRequestId;
    //console.log(tHServiceRequest);
  }

  selectEmployees(employee: ThOffer["employee"]) {
    this.selectedEmployee = employee.employeeId;
  }

  saveThOffer() {
    const srId = this.ThOfferForm.value['thServiceRequest'];
    const eId =  this.ThOfferForm.value['employee'];
    const sr = this.thServiceRequests.filter(thServiceRequest => thServiceRequest.thServiceRequestId === srId)[0];
    sr.employee = this.Employees.filter(employee => employee.employeeId === sr.employeeId)[0];
    sr.client = this.Clients.filter(client => client.clientId === sr.clientId)[0];
    //console.log(this.dataSource.data);
    const tHOffer: ThOffer = {
      confirmationDeadline: this.ThOfferForm.value['confirmationDeadline'],
      offerDate: this.ThOfferForm.value['offerDate'],
      thServiceRequestId: srId,
      thServiceRequest: sr,
      employeeId: eId,
      employee: this.Employees.filter(employee => employee.employeeId === eId)[0],
      offerItems: this.dataSource.data
    }
    //console.log(tHOffer);
    if(this.editData){
      tHOffer.thOfferId = this.editData.thOfferId;
      this.thOfferService.updateTHOffer(tHOffer).subscribe(resp =>{
        this.dialogRef.close();
      })
    }else{
    //console.log(tHOffer);
    this.thOfferService.saveThOffer(tHOffer).subscribe(resp => {
      this.dialogRef.close();
    })
  }
  }

  addOfferItem() {
    this.dialog.open(DialogInsertOfferItemComponent, {
      width: '30%'
    }).afterClosed().subscribe(resp => {
      let id = this.thOfferService.getTHServiceId();
      this.thOfferService.getTHServices().subscribe(resp => {
      
        let offerItem: OfferItem = {
          activationDate: this.thOfferService.getActivationDate(),
          thServiceId: id,
          thService: resp.filter(service => service.thServiceId === id)[0],
        }
        offerItem["thService"]["serviceType"]["description"] = "";
        let data = this.dataSource.data;
        data.push(offerItem);
        this.dataSource = new MatTableDataSource(data);
      })
    })
  }
}

