import { Customer } from './Customer';
import { Stream } from 'stream';


export interface Orders{
    Id: number;
    Customer: Customer;
    Total: number;
    Placed: Date;
    Fulfilled: Date;
    Status: string; 
}