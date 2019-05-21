using Samplee2.CustomExceptionFilter;
using Samplee2.DAL;
using Samplee2.Helpers;
using Samplee2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Samplee2.Controllers
{
    public class EmployeeController : ApiController
    {
        //employee service obj

        private IEmployee employeeServiceObject;


        //parameterised constructor
        public EmployeeController(IEmployee employeeInterface)
        {

            employeeServiceObject = employeeInterface;

        }


        readonly IEmployee employeeServices = new EmployeeHelper();


        //default constructor
        public EmployeeController()
        {

            employeeServiceObject = employeeServices;

        }


        //get method

        [HttpGet]
        public IHttpActionResult GetEmployee()
        {

            var employeeData = employeeServiceObject.GetEmployee();

            if (employeeData == null)
            {
                throw new ProcessException("Records not found");
            }
            else
            {
                return Ok(employeeData);
            }

        }


        //get method

        [HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var employeeDataById = employeeServiceObject.GetEmployeeById(id);

            if (employeeDataById == null)
            {
                throw new ProcessException("Data not found for this id");
            }
            else
            {
                return Ok(employeeDataById);
            }
        }

        //post method

        [HttpPost]
        public IHttpActionResult PostEmployee(EmployeeViewModel employeeViewModel)
        {
           

            var dataToPostForEmployee = employeeServiceObject.PostEmployee(employeeViewModel);
           
            
            return CreatedAtRoute("DefaultApi", new { id = dataToPostForEmployee.ID }, dataToPostForEmployee);


        }

        //put method

        [HttpPut]
        public IHttpActionResult PutEmployee(int id, EmployeeViewModel employeeViewModel)
        {

            var employeePutEmployeeData = employeeServiceObject.PutEmployee(id, employeeViewModel);


            return Ok(employeePutEmployeeData);

        }

        //delete method
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employeeToDelete = employeeServiceObject.DeleteEmployee(id);
            

            return Ok(employeeToDelete);


        }

    }
}

