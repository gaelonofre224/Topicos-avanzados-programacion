using Orders.Api.models.dtos;
using Microsoft.Extensions.Options;
namespace Orders.Api.Services
{
    public class StudentService : IStudentService
    {   
    private readonly IOptions<StudentInfo> _optionsStudentInfo;
        public StudentService(IOptions<StudentInfo> optionsStudentInfo)
        {
            _optionsStudentInfo = optionsStudentInfo;
        }
        public StudentInfo GetStudentInfo()
        {
            return new StudentInfo
            {
                Name = _optionsStudentInfo.Value.Name,
                Password = _optionsStudentInfo.Value.Password
            };
        }
    }
}