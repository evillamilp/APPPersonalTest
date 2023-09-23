import { Component, OnInit, ViewChild} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { lastValueFrom } from 'rxjs';
import { IPersonalTest, PersonalTestService } from '../core';
import { IPersonalGroup } from '../core/interfaces/personalTest/IPersonalTest.interface';
import { MatTable } from '@angular/material/table';

@Component({
    selector: 'app-personal-test',
    templateUrl: './personal-test.component.html',
    styleUrls: ['./personal-test.component.css'],
})
export class PersonalTestComponent implements OnInit
{
    personalTestList: IPersonalTest[]
    register: FormGroup<IPersonalGroup>;
    displayedColumns:string[]
    selected: IPersonalTest | null = null;

    @ViewChild('personalGrid')table: MatTable<IPersonalTest> | null;

    get controls(): IPersonalGroup
    {
        return this.register.controls;
    }

    get controlValues(): IPersonalTest
    {
        return this.register.value
    }

    constructor(
        private _service: PersonalTestService,
        private _fb:FormBuilder
    ){

        this.personalTestList = [] as IPersonalTest[]
        
        this.register = this.onRegisterForm();

        this.displayedColumns = [

            'fullName',
            'address',
            'email',
            'phone',
            'actions'
        ]

        this.table = null

        console.log('register => ', this.register)
    }

    private async loadPersonalList():Promise<void>
    {
        const self   = this
        const result = await lastValueFrom(self._service.getPersonalList())

        self.personalTestList = result

        self.table?.renderRows();
    }

    private async insert():Promise<void>
    {   
        const self = this

        const input = 
        {
            fullName : self.controlValues.fullName,
            address : self.controlValues.address,
            email   : self.controlValues.email,
            phone : self.controlValues.phone
        } as IPersonalTest

        const result = await lastValueFrom( self._service.insertPerson(input));

        if(result !== null)
        {
            await self.loadPersonalList();

            self.register.reset()
        }
    }

    private async edit(element: IPersonalTest):Promise<void>
    {
        const self = this

        element.email = self.controlValues.email
        element.phone = self.controlValues.phone

        const result = await lastValueFrom(self._service.updatePerson(element))
        if(result !== null)
        {
            await self.loadPersonalList()
            self.register.reset()
            self.selected = null
        }
    }

    private setValueForm(element: IPersonalTest):void
    {
       const self = this;

       if(element === null) return;

       self.controls.fullName.setValue(String(element.fullName))
       self.controls.address.setValue(String(element.address))
       self.controls.email.setValue(String(element.email))
       self.controls.phone.setValue(String(element.phone))
    }

    private onRegisterForm():  FormGroup<IPersonalGroup>
    {
        return  this._fb.group({
            fullName : new FormControl<string>('', [Validators.required]),
            address: new FormControl<string>(''),
            email: new FormControl<string>('', [Validators.email]),
            phone: new FormControl<string>('')
        }) as FormGroup<IPersonalGroup>
    }

    private async intialize():Promise<void> 
    {
        const self = this

        await self.loadPersonalList();
    }
    
    async ngOnInit(): Promise<void> {
        
        await this.intialize()
    }

    async click_save($event:MouseEvent):Promise<void> 
    {   
        const self = this

        if(self.selected !== null && Number(self.selected.id) > 0)
        {
            await self.edit(self.selected)
            return;
        }

        await self.insert();
    }
    
    async onClick_edit($event:MouseEvent, element:IPersonalTest ):Promise<void>
    {
        const self = this

        self.selected = element
        self.setValueForm(element)
    }

    async onClick_delete($event: MouseEvent, element: IPersonalTest):Promise<void>
    {
        const self = this

        const result = await lastValueFrom(self._service.deletePerson(Number(element.id)))
        if(result === true)
        {
            await self.loadPersonalList()
        }
    }
}
