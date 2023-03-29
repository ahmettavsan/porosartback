using AutoMapper;
using Core.AbstractManager;
using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericManager<Employee,EmployeeDto> _employeeManager;
        public EmployeeController(IMapper mapper,IGenericManager<Employee,EmployeeDto> employeeManager)
        {
            _mapper = mapper;
            _employeeManager = employeeManager;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = _employeeManager.GetAll();
            //var response=_mapper.Map<List<EmployeeDto>>(employees.ToList());
            return CreateActionResult(CustomResponseDTO<List<EmployeeDto>>.Success(200,employees.ToList()));
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto employeedto)
        {
         
             await  _employeeManager.Add(employeedto);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(201));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee= await _employeeManager.GetById(id); 
            if (employee != null)
            {
                return CreateActionResult(CustomResponseDTO<EmployeeDto>.Success(200, employee));
            }
            return NotFound();
           
        }
        [HttpPut]

        public async Task<IActionResult> Update(EmployeeDto employeedto)
        {
            var result=  _employeeManager.Contains(employeedto.Id);
            if (result!=false)
            {
                if (!ModelState.IsValid)
                {
                    List<ValidationError> errors = new List<ValidationError>();
                    foreach (var error in ModelState) 
                    {
                        errors.Add(new ValidationError { ErrorMessage = error.Value.ToString(), PropertyName = error.Key });
                    }
                    return CreateActionResult(CustomResponseDTO<EmployeeDto>.Fail(400, errors));
                }
                await   _employeeManager.Update(employeedto);
                var updated= await _employeeManager.GetById(employeedto.Id);

                return CreateActionResult(CustomResponseDTO<EmployeeDto>.Success(200, _mapper.Map<EmployeeDto>(updated)));
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await  _employeeManager.GetById(id);
            if(employee is not null)
            {
                await _employeeManager.Delete(employee);
                return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(200));
            }
            return NotFound();
        }
    }
}
