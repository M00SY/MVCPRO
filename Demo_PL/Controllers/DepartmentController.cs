using AutoMapper;
using Demo_BLL.Interfaces;
using Demo_BLL.Repositories;
using Demo_Dal.Entities;
using Demo_PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;

namespace Demo_PL.Controllers
{
    [Authorize(Roles = "HR, Admin")]

    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartmentController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            var departments = unitOfWork.DepartmentRepository.GetAll();
            var departmentvm = mapper.Map<IEnumerable<DepartmentViewModel>>(departments);


            return View(departmentvm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View(new DepartmentViewModel());
        }
        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentvm)
        {
            
            if (ModelState.IsValid)
            {
                #region Manual Mapping

                //var Department = new Department()
                //{
                //    Id = departmentvm.Id,
                //    Name = departmentvm.Name,
                //    Code = departmentvm.Code,
                //    CreationDate = departmentvm.CreationDate,
                //}; 
                #endregion
                var department = mapper.Map<Department>(departmentvm);

                unitOfWork.DepartmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(departmentvm);
            }
        }
        public IActionResult Details(int? id) 
        {
            if(id == null) 
                return NotFound();

            var department = unitOfWork.DepartmentRepository.GetById(id);
            var departmentvm = mapper.Map<DepartmentViewModel>(department);


            if (department == null)
                return NotFound();

            return View(departmentvm);

        }
        [HttpGet]
        public IActionResult Update(int? id) 
        {
            if (id == null)
                return NotFound();

            var department = unitOfWork.DepartmentRepository.GetById(id);
            var departmentvm = mapper.Map<DepartmentViewModel>(department);

            if (department == null)
                return NotFound();
            return View(departmentvm);

        }
        [HttpPost]
        public IActionResult Update(int id,DepartmentViewModel departmentvm)
        {
            if (id != departmentvm.Id)
                return NotFound();
            if(ModelState.IsValid)
            {
                var department = mapper.Map<Department>(departmentvm);

                unitOfWork.DepartmentRepository.Update(department);
                return RedirectToAction(nameof(Index));
            }

            return View(departmentvm);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var department = unitOfWork.DepartmentRepository.GetById(id);
            

            if (department == null)
                return NotFound();

            unitOfWork.DepartmentRepository.Delete(department);
            return RedirectToAction(nameof(Index));

        }

    }
}
