import { Component, inject } from '@angular/core';
import { userModel } from '../../models/user';
import { UserService } from '../../services/userService/user-service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {

}