import { Customer } from './Customer';

export interface Orders{
    Id: number;
    Customer: Customer;
    Total: number;
    Placed: Date;
    Fulfilled: Date;
    Status: string; 
}