using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Departments
{
    public class department
    {
        public string name { get; set; }
        public int amount { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public List<employee> employees { get; set; }
        public List<department> departments { get; set; }

           public department()
        {
            name = "Department";
            phone = "8942342374";
            amount = 3;
            employees = new List<employee>();
            for (int i = 0; i < 3; i++)
            {

                employee emp = new employee();
                emp.name = "employee" + i;
                emp.age = 18 + i;
                emp.phone = "89084327148";

                employees.Add(emp);
            }
        }

    };



    public class employee {
        public string name { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        


       
    
    };
}

/*Для каждого отдела в классе-модели хранится следующая информация:
название отдела (строка)
количество сотрудников объектов (число)
адрес офиса (строка)
телефон офиса (строка)
Для каждого сотрудника хранится следующая информация:
ФИО сотрудника (строка)
возраст (число)
телефон сотрудника (строка)*/