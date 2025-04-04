using AutoMapper;
using Demo_BLL.Interfaces;
using Demo_Dal.Entities;
using Demo_PL.Helpers;
using Demo_PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Data;

namespace Demo_PL.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork _unitOfWork, IMapper _mapper) 
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public IActionResult Index(string? Name, string? Email, int? DeptId)
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeViewModel> employeesvm;

            if (string.IsNullOrWhiteSpace(Name) && string.IsNullOrEmpty(Email) && DeptId == null)
                 employees = unitOfWork.EmployeeRepository.GetAll();
            
            else
                employees = unitOfWork.EmployeeRepository.Search(Name, Email, DeptId);
           
            employeesvm = mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            ViewBag.Department = unitOfWork.DepartmentRepository.GetAll();
            return View(employeesvm);

        }

        public IActionResult Search(string? Name, string? Email, int? DeptId)
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeViewModel> employeesvm;

            if (string.IsNullOrWhiteSpace(Name) && string.IsNullOrEmpty(Email) && DeptId == null)
                employees = unitOfWork.EmployeeRepository.GetAll();

            else
                employees = unitOfWork.EmployeeRepository.Search(Name, Email, DeptId);

            employeesvm = mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            ViewBag.Department = unitOfWork.DepartmentRepository.GetAll();
            return PartialView("EmployeeTablePartialView", employeesvm);

        }

        public IActionResult Create() 
        {
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();
            return View(new EmployeeViewModel());
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeevm)
        {
            if (ModelState.IsValid)
            {
                var employee = mapper.Map<Employee>(employeevm);
                if (employeevm.Image == null)
                    employee.ImageUrl = "";
                else
                    employee.ImageUrl = DocumentSettings.UploadFile(employeevm.Image, "Images");


                unitOfWork.EmployeeRepository.Add(employee);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();
            return View(employeevm);
        }

        public IActionResult Details(int id)
        {
            var employee = unitOfWork.EmployeeRepository.GetById(id);
            var employeevm = mapper.Map<EmployeeViewModel>(employee);
            return View(employeevm);

        }
        public IActionResult Delete(int Id) 
        {
            var employee = unitOfWork.EmployeeRepository.GetById(Id);
            unitOfWork.EmployeeRepository.Delete(employee);
            var isDeleted = DocumentSettings.DeleteFile(employee.ImageUrl, "Images");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();

            var employee = unitOfWork.EmployeeRepository.GetById(id);

            var employeevm = mapper.Map<EmployeeViewModel>(employee);



            if (employee == null)
                return NotFound();

            return View(employeevm);
        }
        [HttpPost]
        public IActionResult Update(int id,EmployeeViewModel employeevm)
        {
            if (id != employeevm.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var employee = mapper.Map<Employee>(employeevm);
                employee.ImageUrl = DocumentSettings.UploadFile(employeevm.Image, "Images");

                unitOfWork.EmployeeRepository.Update(employee);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();
            return View(employeevm);
        }
    }
}
