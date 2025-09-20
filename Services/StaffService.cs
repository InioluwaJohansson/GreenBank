using BankApp.Entities;
using BankApp.Models.DTOs;
using BankApp.Repositories;
namespace BankApp.Services;
public class StaffService{
    private readonly StaffRepository _repository;
    public StaffService(StaffRepository repository){
        _repository = repository;
    }
    public void Register(CreateStaffDto createStaffDto){
        var Staff = new Staff(){
            Role = createStaffDto.Role,
            StaffNo = createStaffDto.StaffNo,
            User = new User{
                LastName = createStaffDto.User.LastName,
                FirstName = createStaffDto.User.FirstName,
                Email = createStaffDto.User.Email,
                Gender = createStaffDto.User.Gender,
                Age = createStaffDto.User.Age,
                AccountStatus = createStaffDto.User.AccountStatus,
                PhoneNumber = createStaffDto.User.PhoneNumber,
                Password = createStaffDto.User.Password,
                Address = new Address{
                    City = createStaffDto.User.City,
                    Country = createStaffDto.User.Country,
                    State = createStaffDto.User.State,
                    NumberLine = createStaffDto.User.NumberLine,
                    PostalCode = createStaffDto.User.PostalCode,
                    Street = createStaffDto.User.Street,
                }
            }
        };
        var response = _repository.Create(Staff);
        if(response){
            Console.WriteLine("Staff Registered Sucessfully");
        }
        else{
            Console.WriteLine("Staff not created");
        }
    }
    public void Edit(string email, UpdateStaffDto updateStaffDto){
        var updatedStaff = _repository.GetbyEmail(email);
        if (updatedStaff != null){
            updatedStaff.Role = updateStaffDto.Role;
            updatedStaff.User.Gender = updateStaffDto.User.Gender;
            updatedStaff.User.FirstName = updateStaffDto.User.FirstName;
            updatedStaff.User.LastName = updateStaffDto.User.LastName;
            updatedStaff.User.PhoneNumber = updateStaffDto.User.PhoneNumber;
            updatedStaff.User.Address.NumberLine = updateStaffDto.User.NumberLine;
            updatedStaff.User.Address.Street = updateStaffDto.User.Street;
            updatedStaff.User.Address.City = updateStaffDto.User.City;
            updatedStaff.User.Address.Country = updateStaffDto.User.Country;
            updatedStaff.User.Address.PostalCode = updateStaffDto.User.PostalCode;
            updatedStaff.User.Address.State = updateStaffDto.User.State;
            var response = _repository.Update(updatedStaff);
            if (response){
                Console.WriteLine("Staff updated sucessfully");
            }
            else{
                Console.WriteLine("Staff update failed");
            }
        }
        else{
            Console.WriteLine("Coustomer not found");
        }
        
    }
    public GetStaffDto Find(string email){
        var Staff = _repository.GetbyEmail(email);
        if (Staff != null)
        {
            return new GetStaffDto(){
                Role = Staff.Role,
                StaffNo = Staff.StaffNo,
                User = new GetUserDto(){
                    Name = $"{Staff.User.LastName} {Staff.User.FirstName}",
                    Email = Staff.User.Email,
                    Gender = Staff.User.Gender,
                    Age = Staff.User.Age,
                    AccountStatus = Staff.User.AccountStatus,
                    PhoneNumber = Staff.User.PhoneNumber,
                    City = Staff.User.Address.City,
                    Country = Staff.User.Address.Country,
                    State = Staff.User.Address.State,
                    NumberLine = Staff.User.Address.NumberLine,
                    PostalCode = Staff.User.Address.PostalCode,
                    Street = Staff.User.Address.Street
                }
            };
        }return null;
    }
    public GetStaffDto Find1(string email, string password){
        var Staff = _repository.GetbyEmail(email);
        if(Staff != null && Staff.User.Password == password){
            return new GetStaffDto(){
                Role = Staff.Role,
                StaffNo = Staff.StaffNo,
                User = new GetUserDto(){
                    Name = $"{Staff.User.LastName} {Staff.User.FirstName}",
                    Email = Staff.User.Email,
                    Gender = Staff.User.Gender,
                    Age = Staff.User.Age,
                    AccountStatus = Staff.User.AccountStatus,
                    PhoneNumber = Staff.User.PhoneNumber,
                    City = Staff.User.Address.City,
                    Country = Staff.User.Address.Country,
                    State = Staff.User.Address.State,
                    NumberLine = Staff.User.Address.NumberLine,
                    PostalCode = Staff.User.Address.PostalCode,
                    Street = Staff.User.Address.Street
                }
            };
        } return null;
    }
    public List<GetStaffDto> GetAll(){
        var Staffs = _repository.List();
        return Staffs.Select(Staff => new GetStaffDto{
            Role = Staff.Role,
            StaffNo = Staff.StaffNo,
            User = new GetUserDto(){
                Name = $"{Staff.User.LastName} {Staff.User.FirstName}",
                Email = Staff.User.Email,
                Gender = Staff.User.Gender,
                Age = Staff.User.Age,
                AccountStatus = Staff.User.AccountStatus,
                PhoneNumber = Staff.User.PhoneNumber,
                City = Staff.User.Address.City,
                Country = Staff.User.Address.Country,
                State = Staff.User.Address.State,
                NumberLine = Staff.User.Address.NumberLine,
                PostalCode = Staff.User.Address.PostalCode,
                Street = Staff.User.Address.Street
            }
        }).ToList();
    }
    public void UpdateAccountStatus(string email, UpdateAccountStatusStaffDto updateAccountStatusStaffDto){
        var updatedCustomer = _repository.GetbyEmail(email);
        if (updatedCustomer != null){
            updatedCustomer.User.AccountStatus = updateAccountStatusStaffDto.User.AccountStatus;
            var response = _repository.UpdateAccountstatus(updatedCustomer);
            if (response){
                Console.WriteLine("Account Status updated sucessfully");
            }else{
                Console.WriteLine("Account Status update failed");
            }
        }
    }
    public string Check(string email){
        var staff = _repository.GetbyEmail(email);
        if (staff != null){   
            Console.WriteLine("This Email Address has been used.");
            Console.WriteLine("Enter Another Valid Email Address To Continue: ");
            var emailCheck = Console.ReadLine();
            return Check(emailCheck);
        }else{
            return email;
        }
    }
}