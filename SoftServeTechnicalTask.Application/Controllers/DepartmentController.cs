using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Application.BuildingBlocks;

namespace SoftServeTechnicalTask.Application.Controllers
{
    [Route("/api/department")]
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Get existing department by Id
        /// </summary>
        /// <param name="departmentId">Id of department which you want to get</param>
        /// <returns>Return department model with all sub-items (department, families, etc)</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Department with such id wasn't found</response>
        [HttpGet("{departmentId}")]
        public async Task<IActionResult> Get([FromRoute]int departmentId)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            return department == null ?
                ReturnNotFound(departmentId) :
                ReturnOk(department);
        }

        /// <summary>
        /// Create new department
        /// </summary>
        /// <param name="department">Object of department which you want to create</param>
        /// <returns>Return status code</returns>
        /// <response code="201">Successfully created</response>
        /// <response code="409">Department with such name already exists</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Department department)
        {
            return await _departmentRepository.CreateAsync(department) ?
                ReturnAcceptedCreated(department) :
                ReturnConflict(department);
        }

        /// <summary>
        /// Update existing department
        /// </summary>
        /// <param name="department">Object of department which you want to update</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully updated</response>
        /// <response code="404">Department with such id wasn't found</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Department department)
        {
            return await _departmentRepository.UpdateAsync(department) ?
                ReturnAcceptedUpdate(department) :
                ReturnNotFound(department.Id);
        }

        /// <summary>
        /// Delete existing department
        /// </summary>
        /// <param name="departmentId">Id of department which you want to delete</param>
        /// <returns>Return status code</returns>
        /// <response code="202">Successfully deleted</response>
        /// <response code="404">Department with such id wasn't found</response>
        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> Delete(int departmentId)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            return await _departmentRepository.DeleteByIdAsync(departmentId) ?
            ReturnAcceptedDelete(department) :
            ReturnNotFound(departmentId);
        }
    }
}
