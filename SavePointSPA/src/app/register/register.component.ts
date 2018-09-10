import { AlertifyService } from './../_services/alertify.service';
import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();

  // variable to hold model state
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    // Register to the auth service and subscribe to the response
    // Output success message if call is successful
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('Registration Successful');
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
