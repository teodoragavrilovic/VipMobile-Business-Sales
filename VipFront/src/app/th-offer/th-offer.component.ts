import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { DialogInsertTPComponent } from '../dialog-insert-tp/dialog-insert-tp.component';
import { ThOffer } from '../models/th-offer/th-offer.model';
import { ThOfferService } from '../services/th-offer/th-offer.service';
import { MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { DialogThOfferComponent } from '../dialog-th-offer/dialog-th-offer.component';

@Component({
  selector: 'app-th-offer',
  templateUrl: './th-offer.component.html',
  styleUrls: ['./th-offer.component.scss']
})
export class ThOfferComponent implements OnInit {
  displayedColumns: string[] = ['thServiceRequestId', 'requestDate', 'approved', 'employee', 'offerDate', 'confirmationDeadline', 'action'];
  dataSource = new MatTableDataSource<ThOffer>();
  
  constructor(private thOfferService: ThOfferService, private dialog: MatDialog) { }

  openDialog() {
    this.dialog.open(DialogThOfferComponent, {
      width: '30%'
    }).afterClosed().subscribe(value => {
      this.getTHOffers();
    });
  }
  ngOnInit(): void {
    this.getTHOffers();
  }

  getTHOffers(){
    this.thOfferService.getThOffers().subscribe( resp =>{
      this.dataSource = new MatTableDataSource(resp);
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  editTHOffer(tHOffer: ThOffer){
    this.dialog.open(DialogThOfferComponent, {
      width: '30%',
      data: tHOffer
    }).afterClosed().subscribe(value => {
      this.getTHOffers();
    });
  }

  deleteTHOffer(tHOffer: ThOffer){
    this.thOfferService.daletetHOffer(tHOffer).subscribe( resp =>{
      this.getTHOffers();
    }
    )
  }
}
