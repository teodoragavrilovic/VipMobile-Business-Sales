import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TariffPackage } from '../models/tariff-package/tariff-package.model';
import { TariffPackageService } from '../services/tariff-package/tariff-package.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-insert-tp',
  templateUrl: './dialog-insert-tp.component.html',
  styleUrls: ['./dialog-insert-tp.component.scss']
})
export class DialogInsertTPComponent implements OnInit {

  TariffPackageForm!: FormGroup;
  selectedPackageType!: TariffPackage["packageType"]['packageTypeId'];
  packageTypes!: TariffPackage["packageType"][];

  actionBtn: string = "Sačuvaj";

  constructor(private formBuilder: FormBuilder,
    private tariffPackageService: TariffPackageService,
    @Inject(MAT_DIALOG_DATA) public editData: TariffPackage,
    private dialogRef: MatDialogRef<DialogInsertTPComponent>
  ) { }
  ngOnInit(): void {
    this.getPackageTypes();
    this.TariffPackageForm = this.formBuilder.group({
      packageType: ['', Validators.required],
      tariffPackageName: ['', Validators.required],
      avlbMinutes: ['', Validators.required],
      avlbSMS: ['', Validators.required],
      avlbMB: ['', Validators.required],
      price: ['', Validators.required]
    });

    if (this.editData) {
      this.TariffPackageForm.controls['packageType'].setValue(this.editData.packageType.packageTypeId);
      this.TariffPackageForm.controls['tariffPackageName'].setValue(this.editData.tariffPackageName);
      this.TariffPackageForm.controls['avlbMinutes'].setValue(this.editData.avlbMinutes);
      this.TariffPackageForm.controls['avlbSMS'].setValue(this.editData.avlbSMS);
      this.TariffPackageForm.controls['avlbMB'].setValue(this.editData.avlbMB);
      this.TariffPackageForm.controls['price'].setValue(this.editData.price);
    }
  }

  getPackageTypes() {
    this.tariffPackageService.getPackageTypes().subscribe(resp => {
      this.packageTypes = resp;
    })
  }

  selectPackageTypes(packageType: TariffPackage["packageType"]) {
    this.selectedPackageType = packageType.packageTypeId;
  }

  saveTariffPackage() {
    //console.log(this.TariffPackageForm);
    const ptId = this.TariffPackageForm.value['packageType'];
    let tariffPackage: TariffPackage = {
      tariffPackageName: this.TariffPackageForm.value['tariffPackageName'],
      avlbMinutes: this.TariffPackageForm.value['avlbMinutes'],
      avlbSMS: this.TariffPackageForm.value['avlbSMS'],
      avlbMB: this.TariffPackageForm.value['avlbMB'],
      price: this.TariffPackageForm.value['price'],
      packageTypeId: ptId,
      packageType: this.packageTypes.filter(packageType => packageType.packageTypeId === ptId)[0]
    }
    if (this.editData) {
      tariffPackage.tariffPackageId = this.editData.tariffPackageId;
      console.log(tariffPackage.packageType);
      this.tariffPackageService.updateTariffPackage(tariffPackage).subscribe(resp => {
        this.dialogRef.close();
      })
    } else {
      this.tariffPackageService.saveTariffPackage(tariffPackage).subscribe(resp => {
        this.dialogRef.close();
      })
    }
  }

}
