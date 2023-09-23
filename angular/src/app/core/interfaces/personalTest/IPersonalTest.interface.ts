import { FormControl } from "@angular/forms";

export interface IPersonalTest 
{
    id?: number | null;
    fullName?: string | null;
    address?: string | null;
    email?: string | null;
    phone?: string | null;
    actions?: string | null; // sería mejor y adecuado un modelo para tablas
}

export interface IPersonalGroup{
    fullName: FormControl<string|null>;
    address: FormControl<string|null>;
    email: FormControl<string|null>;
    phone: FormControl<string|null>;
}