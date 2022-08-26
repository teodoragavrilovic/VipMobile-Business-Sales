import { OfferItem } from "../offer-item/offer-item.model"

export interface ThOffer {
    thOfferId?: number,
    confirmationDeadline: Date,
    offerDate: Date,
    thServiceRequestId: number,
    thServiceRequest:{
        thServiceRequestId: number,
        requestDate: Date,
        approved: Boolean,
        employeeId: number,
        employee:{
            employeeId: number,
            name: string,
            surname: string,
            dateOfBirth: Date
        },
        clientId: number,
        client:{
            clientId: number,
            clientName: string,
            pib: number,
            phoneNumber: string,
            email: string,
            webPage: string,
            yearOfFaundation: number
        }
    },
    employeeId: number,
    employee:{
        employeeId: number,
        name: string,
        surname: string,
        dateOfBirth: Date
    },
    offerItems: OfferItem[]
}
