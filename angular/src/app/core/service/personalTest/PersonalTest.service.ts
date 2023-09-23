import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable, } from 'rxjs';
import { IPersonalTest } from '../../interfaces/personalTest/IPersonalTest.interface';

@Injectable({
    providedIn: 'root'
  })
  export class PersonalTestService 
  {
    private   apiUrl: string = environment.apiUrl + 'api/personal-test/';
    
    constructor(private _http: HttpClient) { }

    public getPersonalList():Observable<IPersonalTest[]>{
        const headers = new HttpHeaders().set('Content-type', 'application/json');

        var httpContext = this._http.get<IPersonalTest[]>(this.apiUrl + `GetPersonalList`, {headers: headers})

        return httpContext
        .pipe(
            map( (res: IPersonalTest[]) => res )
         )
    }

    public insertPerson(input :IPersonalTest):Observable<IPersonalTest>{

      const headers = new HttpHeaders().set('Content-type', 'application/json');

      let httpContext = this._http.post<IPersonalTest>(this.apiUrl + 'InsertPerson', input, { headers });

      return httpContext.pipe( map((res:IPersonalTest) =>  res))
    }

    public updatePerson(input :IPersonalTest):Observable<IPersonalTest>{

      const headers = new HttpHeaders().set('Content-type', 'application/json');

      let httpContext = this._http.put<IPersonalTest>(this.apiUrl + `UpdatePerson/${input.id}`, input, { headers });

      return httpContext.pipe( map((res:IPersonalTest) =>  res))
    }

    public deletePerson(id:number):Observable<boolean>{
      const headers = new HttpHeaders().set('Content-type', 'application/json');

      var httpContext = this._http.delete<boolean>(this.apiUrl + `DeletePerson/${id}`, {headers: headers})

      return httpContext
      .pipe(
          map( (res: boolean) => res )
       )
    }
  }