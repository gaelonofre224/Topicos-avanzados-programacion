using Orders.Api.Services;
using Microsoft.AspNetCore.Mvc;
namespace Orders.Api.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class StudentController : ControllerBase
        {
            private readonly IStudentService _studentService;
            public StudentController(IStudentService studentService)
            {
                _studentService = studentService;    
            }
            [HttpGet]
            public IActionResult GetStudentInfomation()
            {
                var studentInfo = _studentService.GetStudentInfo();
                return StatusCode(200, new {studentInfo});
            }

        
        }
}
