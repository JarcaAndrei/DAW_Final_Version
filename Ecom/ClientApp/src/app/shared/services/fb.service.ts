import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { FacebookLoginProvider } from "angularx-social-login";
import { SocialAuthService } from "angularx-social-login";




const httpoptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class FacebookService {
  

  constructor(
    private http: HttpClient,
    private router:Router,
    private socialauthService: SocialAuthService
    ) { }

    fbLoginOptions = {
      scope: 'pages_manage_engagement,pages_manage_posts,pages_read_engagement,pages_read_user_content,groups_access_member_info,publish_to_groups,instagram_content_publish,instagram_manage_insights,instagram_basic,pages_show_list,publish_video,read_insights,email,public_profile'
    }; 
   
   signInWithFB(): void {
    this.socialauthService.signIn(FacebookLoginProvider.PROVIDER_ID,this.fbLoginOptions);
  }
}
