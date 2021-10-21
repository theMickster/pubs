export interface IUser {
    userId: number;
    userStatusId : number;
    username: string;
    userPrincipalName: string;
    firstName: string;
    middleName: string;
    lastName: string;
    emailAddress: string;
    phoneNumber: string;
    lastSuccessfulLogin: Date;    
}