using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.controller
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// 使用构造函数注入方式依赖注入IStudentRepository
        /// </summary>
        /// <param name="studentRepository"></param>
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            var student = _studentRepository.GetAll();
            return View(student);
        }

        public IActionResult GetDetail(int id)
        {
            Student model = _studentRepository.GetStudent(id);

            return View(model);
        }
    }
}