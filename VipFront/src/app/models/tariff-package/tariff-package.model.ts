export interface TariffPackage {
  tariffPackageId?: number,
  tariffPackageName: string,
  avlbMinutes: number,
  avlbSMS: number,
  avlbMB: number,
  price: number,
  packageTypeId: number,
  packageType: {
    packageTypeId: number,
    typeName: string
  }
}
