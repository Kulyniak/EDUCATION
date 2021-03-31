using EDUCATION.Entities;
using EDUCATION.Models.Base;
using EDUCATION.Models.Questions;
using EDUCATION.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDUCATION.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionsService _questionsService;

        public QuestionsController(QuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpGet, Route("get_questions")]
        public async Task<GetQuestionsResponse> GetQuestionsAsync([FromQuery] UserLevel userLevel) =>
            await _questionsService.GetQuestionsForOnlineUserAsync(userLevel);

        [HttpPost, Route("add_question")]
        public async Task<ApiResponse> AddQuestionAsync([FromBody]AddQuestionRequest request) =>
            await _questionsService.AddQuestionAsync(request);
    }
}
