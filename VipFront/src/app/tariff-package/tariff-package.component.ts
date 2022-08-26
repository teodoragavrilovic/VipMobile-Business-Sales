import { Component, OnInit } from '@angular/core';
import { TariffPackage } from '../models/tariff-package/tariff-package.model';
import { TariffPackageService } from '../services/tariff-package/tariff-package.service';
import { MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { DialogInsertTPComponent } from '../dialog-insert-tp/dialog-insert-tp.component';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-tariff-package',
  templateUrl: './tariff-package.component.html',
  styleUrls: ['./tariff-package.component.scss']
})
export class TariffPackageComponent implements OnInit {
  displayedColumns: string[] = ['tariffPackageName', 'typeName', 'avlbMinutes', 'avlbSMS', 'avlbMB', 'price', 'action'];
  //dataSource: TariffPackage[] = [];
  dataSource = new MatTableDataSource<TariffPackage>();

  constructor(private tariffPackageService: TariffPackageService, private dialog: MatDialog) { }

  openDialog() {
    this.dialog.open(DialogInsertTPComponent, {
      width: '30%'
    }).afterClosed().subscribe(value => {
      this.getTariffPackages();
    });
  }
  ngOnInit(): void {
    this.getTariffPackages();
  }

  getTariffPackages(){
    // console.log("evo sam");
    this.tariffPackageService.getTariffPackages().subscribe( resp => {
      console.log(resp);
      this.dataSource = new MatTableDataSource(resp);
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  editTariffPackage(tariffPackage: TariffPackage){
    this.dialog.open(DialogInsertTPComponent, {
      width: '30%',
      data: tariffPackage
    }).afterClosed().subscribe(value => {
      this.getTariffPackages();
    });
  }

  deleteTariffPackage(tariffPackage: TariffPackage){
    this.tariffPackageService.deleteTariffPackage(tariffPackage).subscribe( resp =>{
      this.getTariffPackages();
    }
    )
  }
}
