import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { APiQuestion } from '../models/questions/api-question.model';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})
export class QuestionsComponent implements OnInit {
  displayedColumns: string[] = ['name', 'answer1', 'answer2', 'answer3', 'answer4'];
  questions = [];

  form: FormGroup;

  constructor(
    private _apiService: ApiService,
    private _fb: FormBuilder)
  { }

  async ngOnInit() {
    try {
      let response = await this._apiService.getQuestionsByUserLevelAsync('beginer');
      if (!response.isSuccess) {
        return;
      }

      this.questions = response.questions;
      console.log(this.questions)

      this.buildForm();
    }
    finally {
      
    }
  }

  submit() {
    let request = this.form.value;
    console.log(request);
  }

  buildForm() {
    this.form = this._fb.group({
      name: [''],
      type: [0],
      level: [0],
      testAnswer1: [''],
      testAnswer2: [''],
      testAnswer3: [''],
      testAnswer4: [''],
      rightTestAnswer: [''],
      rightWordAnswer: [''],
      userId:[4]
    })
  }

}
