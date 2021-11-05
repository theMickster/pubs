export class User{

    constructor(
        public userId: number = null,
        public userStatusId : number = null,
        public username: string = null,
        public userPrincipalName: string = null,
        public firstName: string = null,
        public middleName: string = null,
        public lastName: string = null,
        public emailAddress: string = null,
        public phoneNumber: string = null,
        public lastSuccessfulLogin: Date = null
    )
    {
    }

    public get fullName () : string {
        if(this.isEmptyOrSpaces(this.middleName)){
            return `${this.firstName} ${this.lastName}`
        }
        else{
            return `${this.firstName} ${this.middleName} ${this.lastName}`
        }        
    }


    private isEmptyOrSpaces(input): boolean {
        return input === null || input.match(/^ *$/) !== null;
    }
}