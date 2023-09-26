import { group } from "@angular/animations";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControlName, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../Service/auth.service";

@Component({
    selector: 'login-component',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class logincomponent implements OnInit {
    validation !: FormGroup
    displymsg: string = '';
    // iscreted: boolean = false;
    constructor(public login: FormBuilder, private authService: AuthService) { }
    ngOnInit(): void {
        this.validation = this.login.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            // number: ['', [Validators.required, Validators.pattern("[0-9]{10}")]],
            gender: ['', Validators.required],
            password: ['', [Validators.required, Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@#$!%*?&])[A-Za-z0-9\d$@#$!%*?&].{8,15}')]]
        })
    }
    Onsubmit() {
        console.log(this.validation.valid);
        if (this.validation.valid) {

            this.authService.registerUser([
                this.validation.value.firstName,
                this.validation.value.lastName,
                this.validation.value.gender,
                this.validation.value.email,
                this.validation.value.password
            ]).subscribe(arg => {
                if (arg == 'added successfully') {
                    this.displymsg = "Account Created "
                } else if (arg == "find.FirstOrDefault()") {
                    this.displymsg = "Email already Exist";
                }
            });
        }
    }
}