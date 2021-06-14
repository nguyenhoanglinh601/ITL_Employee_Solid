export class Employee{
    constructor(public id: number, 
                public name: string, 
                public phoneNumber: string, 
                public email: string,
                public status: boolean){
        this.id= id;
        this.name= name;
        this.phoneNumber= phoneNumber;
        this.email= email;
        this.status= status;
    }
}