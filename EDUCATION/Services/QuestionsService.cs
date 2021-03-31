using EDUCATION.Entities;
using EDUCATION.Models;
using EDUCATION.Models.Base;
using EDUCATION.Models.Questions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EDUCATION.Services
{
    public class QuestionsService : BaseService
    {
        public async Task<GetQuestionsResponse> GetQuestionsForOnlineUserAsync(UserLevel userLevel)
        {
            return await GetResponseAsync(async () =>
            {
                var response = new GetQuestionsResponse();

                using (var db = new EFDbContext())
                {
                    var questionsQuery = db.Questions.AsNoTracking().Where(x => !x.IsDeleted && x.Level == userLevel).AsQueryable();

                    switch (userLevel)
                    {
                        case UserLevel.Beginer:
                            questionsQuery = questionsQuery.Take(Constants.BEGINER_QUESTIONS_COUNT);
                            break;
                        case UserLevel.Intermediate:
                            questionsQuery = questionsQuery.Take(Constants.INTERMEDIATE_QUESTIONS_COUNT);
                            break;
                        case UserLevel.Pro:
                            questionsQuery = questionsQuery.Take(Constants.PRO_QUESTIONS_COUNT);
                            break;
                        default:
                            questionsQuery = questionsQuery.Take(Constants.BEGINER_QUESTIONS_COUNT);
                            break;
                    }

                    var questionEntities = await questionsQuery.ToListAsync();

                    if(questionEntities == null || questionEntities.Count == 0)
                    {
                        throw new Exception("questions not found");
                    }

                    var questions = questionEntities.Select(x => new ApiQuestion
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Type = x.Type,
                        Level = x.Level,
                        TestAnswer1 = x.TestAnswer1,
                        TestAnswer2 = x.TestAnswer2,
                        TestAnswer3 = x.TestAnswer3,
                        TestAnswer4 = x.TestAnswer4,
                    }).ToList();

                    response.Questions = questions;
                }

                return response;
            });
        }

        public async Task<ApiResponse> AddQuestionAsync(AddQuestionRequest request)
        {
            return await GetResponseAsync(async () =>
            {
                var response = new ApiResponse();

                using (var db = new EFDbContext())
                {
                    // TODO: Valodation as login

                    var questionEntity = new Question
                    {
                        Name = request.Name,
                        Type = request.Type,
                        Level = request.Level,
                        TestAnswer1 = request.TestAnswer1,
                        TestAnswer2 = request.TestAnswer2,
                        TestAnswer3 = request.TestAnswer3,
                        TestAnswer4 = request.TestAnswer4,
                        RightTestAnswer = request.RightTestAnswer,
                        RightWordAnswer = request.RightWordAnswer,
                        UserId = request.UserId,
                        LastActionDate = DateTime.UtcNow
                    };

                    db.Questions.Add(questionEntity);
                    await db.SaveChangesAsync();
                }

                return response;
            });
        }
    }
}
