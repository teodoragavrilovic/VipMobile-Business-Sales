import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OfferItem } from '../models/offer-item/offer-item.model';
import { ThOfferService } from '../services/th-offer/th-offer.service';

@Component({
  selector: 'app-dialog-insert-offer-item',
  templateUrl: './dialog-insert-offer-item.component.html',
  styleUrls: ['./dialog-insert-offer-item.component.scss']
})
export class DialogInsertOfferItemComponent implements OnInit {

  OfferItemForm!: FormGroup;
  tHServices!: OfferItem["thService"][];
  selectedTHService!: OfferItem["thService"]["thServiceId"];
  constructor(private formBuilder: FormBuilder,
    private thOfferService: ThOfferService,
    private dialogRef: MatDialogRef<DialogInsertOfferItemComponent>,
    @Inject(MAT_DIALOG_DATA) public editData: OfferItem
  ) { }

  actionBtn: string = "Dodaj";

  ngOnInit(): void {

    this.getTHService();

    this.OfferItemForm = this.formBuilder.group({
      tHService: ['', Validators.required],
      activationDate: ['', Validators.required],
    })
    if (this.editData) {
      this.OfferItemForm.controls['tHService'].setValue(this.editData.thService.thServiceId),
        this.OfferItemForm.controls['activationDate'].setValue(this.editData.activationDate)
    }
  }

  getTHService() {
    this.thOfferService.getTHServices().subscribe(resp => {
      this.tHServices = resp;
    })
  }

  selectThServiceRequests(tHService: OfferItem["thService"]) {

   // console.log(tHService);
    this.selectedTHService = tHService.thServiceId;
   // console.log(this.selectedTHService);
  }

  addOfferItem() {
    this.thOfferService.setActivationDate(this.OfferItemForm.value['activationDate']);
    this.thOfferService.setTHServiceID(this.OfferItemForm.value['tHService']);
    this.dialogRef.close();
  }
}
