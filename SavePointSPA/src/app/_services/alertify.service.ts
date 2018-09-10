import { Injectable } from '@angular/core';

declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

// Confirm message using alertify
// Needs message and okCallback function
confirm(message, okCallback: () => any) {
  alertify.confirm(message, function(e) {
    if (e) {
      okCallback();
    } else {}
  });
}

success(message: string) {
  alertify.success(message);
}

error(message: string) {
  alertify.success(message);
}

warning(message: string) {
  alertify.success(message);
}

message(message: string) {
  alertify.success(message);
}

}