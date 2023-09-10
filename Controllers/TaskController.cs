using Microsoft.AspNetCore.Mvc;

namespace FirstTask.Controllers{
    [ApiController]
    public class TaskController : ControllerBase{

        [HttpGet]
        [Route("api")]
        public IActionResult ReturnTask(string? slack_name, string? track)
        {
            try{

                if(string.IsNullOrEmpty(slack_name) || string.IsNullOrEmpty(track))
                {
                    return BadRequest("Both slack name and track cannot be null :)");
                }

                var jsonItem = new{
                    slack_name,
                    current_day = DateTime.UtcNow.DayOfWeek.ToString(),
                    utc_time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    track = track.ToLower(),
                    github_file_url = "https://github.com/bahdman/HNGInternshipFirstTask/blob/main/Controllers/TaskController.cs",
                    github_repo_url = "https://github.com/bahdman/HNGInternshipFirstTask",
                    status_code = Response.StatusCode
                };

                return Ok(jsonItem);

            }catch(Exception ex)
            {
                var statusCode = Response.StatusCode = 500;
                return StatusCode(statusCode, ex.Message);
            };
        }    
    }
}