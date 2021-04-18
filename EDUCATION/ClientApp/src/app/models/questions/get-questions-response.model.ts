import { ApiResponse } from "../api-response.model";
import { APiQuestion } from "./api-question.model";

export class GetQuestionsResponse extends ApiResponse {
  public questions: Array<APiQuestion>
}
