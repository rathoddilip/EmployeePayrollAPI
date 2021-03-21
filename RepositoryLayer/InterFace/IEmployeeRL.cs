using CommanLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.InterFace
{
    public interface IEmployeeRL
    {
        public List<EmployeeModel> ReturnEmployeeRecords();
        public string AddEmployeeRecord(EmployeeModel employee);

        public bool DeleteEmployeeRecord(int EmpId);

        public bool UpdateEmployeeRecord(EmployeeModel employee);
    }
}
