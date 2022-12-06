export interface LoanApplicationResponse {
    loanApplications: LoanApplications[],
    personalInformation: PersonalInformation
}



export interface PersonalInformation {
    id: string;
    personalNumber: string;
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: number;
}

export interface LoanApplications {
    id: string;
    amount: number,
    durationYears: number,
    loanType: LoanType,
    applicationDate: Date
}



export enum LoanType {
    PrivateLoan = 1,
    Mortgage = 2
}