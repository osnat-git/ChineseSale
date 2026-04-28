import { Component, Inject, inject } from '@angular/core';
import { userModel } from '../../models/user';
import { UserService } from '../../services/userService/user-service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
   
}