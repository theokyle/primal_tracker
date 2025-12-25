import { Component, inject } from '@angular/core';
import { Router, RouterLink } from "@angular/router";
import { AccountService } from '../../core/service/account-service';
import { LoginCreds } from '../../types/user';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-nav',
  imports: [RouterLink, FormsModule],
  templateUrl: './nav.html',
  styleUrl: './nav.css',
})
export class Nav {
  protected accountService = inject(AccountService);
  protected creds: LoginCreds = { email: "", password: ""};
  private router = inject(Router);

  login() {
    this.accountService.login(this.creds).subscribe({
      next: () => {
        this.creds = { email: "", password: ""};
      },
      error: error => {
        console.log(error);
      }
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
