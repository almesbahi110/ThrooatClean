using Application.Dtos.Requst;
using Application.Dtos.Response;
using Application.Interface;
using Application.Repository;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
       this._employeeRepository =employeeRepository;
            this._mapper = mapper;
        }

        public async Task<IReadOnlyList<Employee>> GetAll()
        {
            var employees = await _employeeRepository.GetAll();
            return employees;


        }
        public async Task<ResponeEmployeeDto> Delete(int id)
        {

            var res = await _employeeRepository.Delete(id);
            ResponeEmployeeDto empDto = new ResponeEmployeeDto();
            empDto.Success = res.Success;
            empDto.Massage = res.Massage;
            return empDto;

        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            var res =await _employeeRepository.GetById(id);
          return res;
        }

        public async Task<ResponeEmployeeDto> PostData(EmployeeRequstDTo data)
        {
            ResponeEmployeeDto responeEmployeeDto = new ResponeEmployeeDto();
            try
            {

                var (state, Massage) = data.ValidteEmployee();
                if(state==1)
                {
                    var q = new Employee()
                    {
                        Birthdate = data.Birthdate,
                        Department = data.Department,
                        EmployeeName = data.EmployeeName,
                        EmployeeState = data.EmployeeState,
                        Gender = data.Gender,
                        PhoneNumber = data.PhoneNumber
                    };

                    var (ss, Msg) = await _employeeRepository.PostData(q);
                    if (ss == 1)
                    {

                        responeEmployeeDto.Success = true;
                        responeEmployeeDto.Massage = "تم اضافه الموظف بنجاح";
                        return responeEmployeeDto;
                    }
                    else
                    {
                        responeEmployeeDto.Success = false;
                        responeEmployeeDto.Massage = "لم يتم اضافه الموظف بنجاح";
                        return responeEmployeeDto;
                    }
                }
                else
                {
                    responeEmployeeDto.Success = false;
                    responeEmployeeDto.Massage = Massage;
                    return responeEmployeeDto;
                }


               
              
                   
                
            }
            catch (Exception ex)
            {
                responeEmployeeDto.Success = false;
                responeEmployeeDto.Massage = "لم يتم اضافه الموظف بنجاح"+ex.Message;
                return responeEmployeeDto;
            }
        }




        public async Task<ResponeEmployeeDto> UpdateData(EmployeeRequstDTo data)
        {
            var (state, Massage) = data.ValidteEmployee();
            ResponeEmployeeDto responeEmployeeDto = new ResponeEmployeeDto();
            try
            {
               
                if (state == 1)
                {
                    var q = new Employee()
                    {
                        EmployeeId=data.EmployeeId,
                        Birthdate = data.Birthdate,
                        Department = data.Department,
                        EmployeeName = data.EmployeeName,
                        EmployeeState = data.EmployeeState,
                        Gender = data.Gender,
                        PhoneNumber = data.PhoneNumber
                    };

                    var (ss, Msg) = await _employeeRepository.UpdateData(q);
                    if (ss == 1)
                    {

                        responeEmployeeDto.Success = true;
                        responeEmployeeDto.Massage = "تم تعديل الموظف بنجاح";
                        return responeEmployeeDto;
                    }
                    else
                    {
                        responeEmployeeDto.Success = false;
                        responeEmployeeDto.Massage = "لم يتم تعديل الموظف بنجاح";
                        return responeEmployeeDto;
                    }
                }
                else
                {
                    responeEmployeeDto.Success = false;
                    responeEmployeeDto.Massage = Massage;
                    return responeEmployeeDto;
                }
            }
            catch (Exception ex)
            {
                responeEmployeeDto.Success = false;
                responeEmployeeDto.Massage = "لم يتم تعديل الموظف بنجاح" + ex.Message;
                return responeEmployeeDto;
            }
        }


    }
}
