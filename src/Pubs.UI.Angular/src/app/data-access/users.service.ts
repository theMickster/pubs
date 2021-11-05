import { Injectable } from '@angular/core';
import { User } from '../data-structures/models/User';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor() { 

  }

  public getUser(userName: string, password: string) : User {
    
    if(userName == 'mletofsky') {
      let lastLoginDateTime = new Date();
      return new User(1, 1, 'mletofsky',  '1573622010197005@mil', 'Mick', null, 'Letofsky', 'mick.letofsky@gmail.com', '3038090122', lastLoginDateTime);
    }
    else{
      return null;
    }

  }
}
