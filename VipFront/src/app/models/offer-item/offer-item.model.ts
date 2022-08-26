export interface OfferItem{

    offerItemId?: number,
    tHOfferId?: number,
    activationDate: Date,
    thServiceId: number,
    thService:{
        thServiceId: number,
        serviceName: string,
        servicePrice: number,
        serviceTypeId: number,
        serviceType:{
            serviceTypeId: number,
            serviceTypeName: string,
            description: string
        }
    }
}

