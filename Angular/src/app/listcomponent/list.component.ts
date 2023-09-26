import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";

@Component({
    selector: 'list-component',
    templateUrl: './list.component.html'
})
export class ListComponent implements OnInit {

    constructor(private http: HttpClient) { }
    user: Array<{ id: Int32Array, firstName: string, lastName: string, gender: string, email: string, password: string }> = [];

    ngOnInit(): void {
        this.http.get('http://localhost:5295/api/Login/GetUsers').subscribe(t => {
            return this.user = t as Array<{ id: Int32Array, firstName: string, lastName: string, gender: string, email: string, password: string }>;
        })
    }
} 