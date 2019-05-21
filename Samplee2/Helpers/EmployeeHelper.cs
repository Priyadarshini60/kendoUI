using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Samplee2.DAL;
using Samplee2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Helpers;
using System.Web.Http;

namespace Samplee2.Helpers
{
    #region
    public class EmployeeHelper : IDisposable, IEmployee
    {

        private EmployeeEntities employeeEntities = new EmployeeEntities();

        //delete method
        public List<Employee_tbl> DeleteEmployee(int id)
        {

            var employeeData = employeeEntities.Employee_tbl.Find(id);

            employeeEntities.Employee_tbl.Remove(employeeData);

            employeeEntities.SaveChanges();

            return employeeEntities.Employee_tbl.ToList();
        }

        //get method
        public IEnumerable<EmployeeViewModel> GetEmployee()
        {
            return employeeEntities.Employee_tbl.ToList().Select(Mapper.Map<Employee_tbl, EmployeeViewModel>);
        }
        //get by id methid
        public Employee_tbl GetEmployeeById(int id)
        {
            return employeeEntities.Employee_tbl.Where(a => a.ID == id).FirstOrDefault();
        }
        //post method
        public Employee_tbl PostEmployee([FromBody]EmployeeViewModel employeeViewModel)
         {

            
            var employeeObject = Mapper.Map<EmployeeViewModel, Employee_tbl>(employeeViewModel);

            employeeEntities.Employee_tbl.Add(employeeObject);
            employeeEntities.SaveChanges();

            return employeeObject;
        }
        //put method
        public Employee_tbl PutEmployee(int id,[FromBody] EmployeeViewModel empViewModelObj)
        {
            var employeeData = employeeEntities.Employee_tbl.FirstOrDefault(a => a.ID == id);


          //  empViewModelObj.Birthdate =(Convert.ToDateTime(empViewModelObj.Birthdate));

            Mapper.Map<EmployeeViewModel, Employee_tbl>(empViewModelObj, employeeData);
            employeeData.ID = id;
            employeeEntities.SaveChanges();
            return employeeData;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (employeeEntities != null)
                {
                    employeeEntities.Dispose();
                    employeeEntities = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
    #endregion
}