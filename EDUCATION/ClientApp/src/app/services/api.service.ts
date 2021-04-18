import { HttpErrorResponse } from "@angular/common/http";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ApiResponse } from "../models/api-response.model";
import { GetQuestionsResponse } from "../models/questions/get-questions-response.model";

@Injectable({ providedIn: 'root' })
export class ApiService {

  constructor(private _httpClient: HttpClient) { }

  public async tryCallApiAsync<T extends ApiResponse>(apiUrl: string, method: string, request?: any, silentModeErrorMessage: boolean = false): Promise<T> {
    let response = {} as T;
    try {
      if (method == 'POST') {
        response = await this._httpClient.post<T>(apiUrl, request/*, { headers: this._headers }*/).toPromise();
      }
      else {
        response = await this._httpClient.get<T>(apiUrl/*, { headers: this._headers }*/).toPromise();
      }
      //if (!response.success && response.error && !silentModeErrorMessage) {
      //  this._snackService.showErrorMessage(response.error);
      //}
    }
    catch (ex) {
      console.error("api->catch: " + JSON.stringify(ex));
      response.isSuccess = false;
      response.message = ex.message;
      if (ex instanceof HttpErrorResponse) {
        /*this.handleException(ex);*/
      }
      else if (!silentModeErrorMessage) {
        //this._snackService.showErrorMessage(ex.message);
      }
    }
    //response.apiUrl = apiUrl;
    return response;
  }

  public async getQuestionsByUserLevelAsync(userLevel: string): Promise<GetQuestionsResponse> {
    const response = await this.tryCallApiAsync<GetQuestionsResponse>(`api/questions/get_questions?userLevel=${userLevel}`, 'GET');
    return response;
  }
}
