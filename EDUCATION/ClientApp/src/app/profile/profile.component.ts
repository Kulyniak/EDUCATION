import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public progresLevel: number = 35;

  constructor(public _apiService: ApiService) { }

  async ngOnInit() {
    let response = await this._apiService.getQuestionsByUserLevelAsync('beginer');
    console.log(response.questions);
    this.progresLevel = response.questions.length
  }

}
