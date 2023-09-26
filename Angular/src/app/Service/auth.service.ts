import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseurl = "http://localhost:5295/api/";
  constructor(private http: HttpClient) { }

  registerUser(user: Array<string>) {
    return this.http.post("http://localhost:5295/api/Login/InsertUser", {
      firstName: user[0],
      lastName: user[1],
      gender: user[2],
      email: user[3],
      password: user[4]
    }, { responseType: "text" })
  }
  // GetUser(user:Array<string>){
  //   return this.http.get(this.baseurl + "Login/GetUsers" )
  // }
}
