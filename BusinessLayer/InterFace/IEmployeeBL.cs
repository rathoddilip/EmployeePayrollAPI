using CommanLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.InterFace
{
    public interface IEmployeeBL
    {
        public List<EmployeeModel> ReturnEmployeeRecords();
        public string RegisterRecord(EmployeeModel employee);
        public bool DeleteEmployeeRecord(int EmpId);
        public bool UpdateEmployeeRecord(EmployeeModel employee);
    }
}
