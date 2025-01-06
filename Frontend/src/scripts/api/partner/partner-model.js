export class Partner{
    constructor(firstName, lastName, address, partnerNumber, croatianPin, partnerTypeId, createdAtUtc, createdByUser, isForeign, externalCode, gender){
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.partnerNumber = partnerNumber;
        this.croatianPin = croatianPin;
        this.partnerTypeId = partnerTypeId;
        this.createdAtUtc = createdAtUtc;
        this.createdByUser = createdByUser;
        this.isForeign = isForeign;
        this.externalCode = externalCode;
        this.gender = gender;
    }
}