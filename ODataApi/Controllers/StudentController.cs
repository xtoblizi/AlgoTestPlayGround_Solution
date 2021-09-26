using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataApi.Controllers
{
	public class StudentController: ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public StudentController(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IActionResult> GetStudent()
		{
			return Ok(await Task.FromResult(GetStudents));

		}

		private List<Student> GetStudents => new List<Student>
		{
			new Student
			{
				Id = 1,
				Name = "Chris",
				Score = 1324,
			},
			new Student
			{
				Id = 2,
				Name = "Daniel",
				Score = 43453.049m
			},
			new Student
			{
				Id = 3,
				Name = "Dammy",
				Score = 903403
			}
		};
	}
}
