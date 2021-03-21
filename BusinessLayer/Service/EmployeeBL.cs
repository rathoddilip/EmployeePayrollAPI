using BusinessLayer.InterFace;
using CommanLayer.ResponseModel;
using RepositoryLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeBL: IEmployeeBL
    {
        IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }
        public List<EmployeeModel> ReturnEmployeeRecords()
        {
            return this.employeeRL.ReturnEmployeeRecords();
        }
        public string RegisterRecord(EmployeeModel employee)
        {
            try
            {
                return this.employeeRL.AddEmployeeRecord(employee);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public bool DeleteEmployeeRecord(int emp_id)
        {
            try
            {
                return this.employeeRL.DeleteEmployeeRecord(emp_id);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateEmployeeRecord(EmployeeModel employee)
        {
            try
            {
                return this.employeeRL.UpdateEmployeeRecord(employee);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
