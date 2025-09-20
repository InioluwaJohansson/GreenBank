using BankApp.Entities;
using BankApp.Models.DTOs;
using BankApp.Repositories;
namespace BankApp.Services;
public class CustomerService{
    CustomerRepository _repository;
    public CustomerService(CustomerRepository repository){
        _repository = repository;
    }
    public bool Register(CreateCustomerDto createCustomerDto){
        var customer = new Customer(){
            Loans = createCustomerDto.Loans,
            LoanPay = createCustomerDto.LoanPay,
            NextOfKin = createCustomerDto.NextOfKin,
            DateOfBirth = createCustomerDto.DateOfBirth,
            BVN = createCustomerDto.BVN,
            NIN = createCustomerDto.NIN,
            Balance = createCustomerDto.Balance,
            AccountNumber = createCustomerDto.AccountNumber,
            AccountType = createCustomerDto.AccountType,
            User = new User{
                LastName = createCustomerDto.User.LastName,
                FirstName = createCustomerDto.User.FirstName,
                Email = createCustomerDto.User.Email,
                Gender = createCustomerDto.User.Gender,
                Age = createCustomerDto.User.Age,
                AccountStatus = createCustomerDto.User.AccountStatus,
                PhoneNumber = createCustomerDto.User.PhoneNumber,
                Password = createCustomerDto.User.Password,
                Address = new Address{
                    City = createCustomerDto.User.City,
                    Country = createCustomerDto.User.Country,
                    State = createCustomerDto.User.State,
                    NumberLine = createCustomerDto.User.NumberLine,
                    PostalCode = createCustomerDto.User.PostalCode,
                    Street = createCustomerDto.User.Street,
                }
            }
        };
        var response = _repository.Create(customer);
        if (response){
            Console.WriteLine($"Customer created Sucessfully. Your Account Number Is {createCustomerDto.AccountNumber}");
            return true;
        }else{
            Console.WriteLine("Customer not created");
            return false;
        }
    }
    public void Edit(string accountNumber, UpdateCustomerDto updateCustomerDto){
        var updatedCustomer = _repository.GetbyAccountNumber(accountNumber);
        if (updatedCustomer != null){
            updatedCustomer.AccountType = updateCustomerDto.AccountType;
            updatedCustomer.BVN = updateCustomerDto.BVN;
            updatedCustomer.NIN = updateCustomerDto.NIN;
            updatedCustomer.NextOfKin = updateCustomerDto.NextOfKin;
            updatedCustomer.DateOfBirth = updateCustomerDto.DateOfBirth;
            updatedCustomer.User.Gender = updateCustomerDto.User.Gender;
            updatedCustomer.User.FirstName = updateCustomerDto.User.FirstName;
            updatedCustomer.User.LastName = updateCustomerDto.User.LastName;
            updatedCustomer.User.PhoneNumber = updateCustomerDto.User.PhoneNumber;
            updatedCustomer.User.Address.NumberLine = updateCustomerDto.User.NumberLine;
            updatedCustomer.User.Address.Street = updateCustomerDto.User.Street;
            updatedCustomer.User.Address.City = updateCustomerDto.User.City;
            updatedCustomer.User.Address.Country = updateCustomerDto.User.Country;
            updatedCustomer.User.Address.PostalCode = updateCustomerDto.User.PostalCode;
            updatedCustomer.User.Address.State = updateCustomerDto.User.State;
            var response = _repository.Update(updatedCustomer);
            if (response){
                Console.WriteLine("Account updated sucessfully");
            }else{
                Console.WriteLine("Account update unsucessful");
            }
        }
    }
    public GetCustomerDto Find(string accountNumber, string password){
        var customer = _repository.GetbyAccountNumber(accountNumber);
        if (customer != null && customer.User.Password == password){
            return new GetCustomerDto{
                NextOfKin = customer.NextOfKin,
                DateOfBirth = customer.DateOfBirth,
                AccountType = customer.AccountType,
                AccountNumber = customer.AccountNumber,
                LoanPay = customer.LoanPay,
                Loans = customer.Loans,
                Balance = customer.Balance,
                BVN = customer.BVN,
                NIN = customer.NIN,
                User = new GetUserDto{
                    Name = $"{customer.User.FirstName} {customer.User.LastName}",
                    Email = customer.User.Email,
                    Gender = customer.User.Gender,
                    Age = customer.User.Age,
                    AccountStatus = customer.User.AccountStatus,
                    PhoneNumber = customer.User.PhoneNumber,
                    City = customer.User.Address.City,
                    Country = customer.User.Address.Country,
                    State = customer.User.Address.State,
                    NumberLine = customer.User.Address.NumberLine,
                    PostalCode = customer.User.Address.PostalCode,
                    Street = customer.User.Address.Street
                }
            };
        }
        return null;
    }
    public GetCustomerDto Find1(string accountNumber){
        var customer = _repository.GetbyAccountNumber(accountNumber);
        if (customer != null){
            return new GetCustomerDto(){
                NextOfKin = customer.NextOfKin,
                DateOfBirth = customer.DateOfBirth,
                AccountType = customer.AccountType,
                AccountNumber = customer.AccountNumber,
                Balance = customer.Balance,
                BVN = customer.BVN,
                NIN = customer.NIN,
                LoanPay = customer.LoanPay,
                Loans = customer.Loans,
                User = new GetUserDto(){
                    Name = $"{customer.User.FirstName} {customer.User.LastName}",
                    Email = customer.User.Email,
                    Gender = customer.User.Gender,
                    Age = customer.User.Age,
                    AccountStatus = customer.User.AccountStatus,
                    PhoneNumber = customer.User.PhoneNumber,
                    City = customer.User.Address.City,
                    Country = customer.User.Address.Country,
                    State = customer.User.Address.State,
                    NumberLine = customer.User.Address.NumberLine,
                    PostalCode = customer.User.Address.PostalCode,
                    Street = customer.User.Address.Street
                }
            };
        }
        return null;
    }
    public GetCustomerPasswordDto TransferCustomer(string accountNumber){
        var customer = _repository.GetbyAccountNumber(accountNumber);
        if (customer != null){
            return new GetCustomerPasswordDto(){
                NextOfKin = customer.NextOfKin,
                DateOfBirth = customer.DateOfBirth,
                AccountType = customer.AccountType,
                AccountNumber = customer.AccountNumber,
                Balance = customer.Balance,
                BVN = customer.BVN,
                NIN = customer.NIN,
                User = new GetUserPasswordDto(){
                    Name = $"{customer.User.FirstName} {customer.User.LastName}",
                    Email = customer.User.Email,
                    Password = customer.User.Password,
                    Gender = customer.User.Gender,
                    Age = customer.User.Age,
                    AccountStatus = customer.User.AccountStatus,
                    PhoneNumber = customer.User.PhoneNumber,
                    City = customer.User.Address.City,
                    Country = customer.User.Address.Country,
                    State = customer.User.Address.State,
                    NumberLine = customer.User.Address.NumberLine,
                    PostalCode = customer.User.Address.PostalCode,
                    Street = customer.User.Address.Street
                }
            };
        }
        return null;
    }
    public List<GetCustomerDto> GetAll(){
        var customers = _repository.List();
        return customers.Select(customer => new GetCustomerDto{
            NextOfKin = customer.NextOfKin,
            DateOfBirth = customer.DateOfBirth,
            AccountType = customer.AccountType,
            AccountNumber = customer.AccountNumber,
            Balance = customer.Balance,
            BVN = customer.BVN,
            NIN = customer.NIN,
            User = new GetUserDto(){
                Name = $"{customer.User.LastName} {customer.User.FirstName}",
                Email = customer.User.Email,
                Gender = customer.User.Gender,
                Age = customer.User.Age,
                AccountStatus = customer.User.AccountStatus,
                PhoneNumber = customer.User.PhoneNumber,
                City = customer.User.Address.City,
                Country = customer.User.Address.Country,
                State = customer.User.Address.State,
                NumberLine = customer.User.Address.NumberLine,
                PostalCode = customer.User.Address.PostalCode,
                Street = customer.User.Address.Street
            }
        }).ToList();
    }
    public void UpdatePassword(string accountNumber, UpdatePasswordCustomerDto updatePasswordCustomerDto){
        var updatedCustomer = _repository.GetbyAccountNumber(accountNumber);
        if (updatedCustomer != null){
            updatedCustomer.User.Password = updatePasswordCustomerDto.User.Password;
            var response = _repository.UpdatePassword(updatedCustomer);
            if (response){
                Console.WriteLine("Password updated sucessfully");
            }else{
                Console.WriteLine("Password update failed");
            }
        }
    }
    public void UpdateBalance(string accountNumber, UpdateBalanceCustomerDto updateBalanceCustomerDto){
        var updatedCustomer = _repository.GetbyAccountNumber(accountNumber);
        if (updatedCustomer != null){
            updatedCustomer.Balance = updateBalanceCustomerDto.Balance;
            var response = _repository.UpdatePassword(updatedCustomer);
        }
    }
    public void UpdateAccountStatus(string accountNumber, UpdateAccountStatusCustomerDto updateAccountStatusCustomerDto){
        var updatedCustomer = _repository.GetbyAccountNumber(accountNumber);
        if (updatedCustomer != null){
            updatedCustomer.User.AccountStatus = updateAccountStatusCustomerDto.User.AccountStatus;
            var response = _repository.UpdateAccountstatus(updatedCustomer);
            if (response){
                Console.WriteLine("Account Status updated sucessfully");
            }else{
                Console.WriteLine("Account Status update failed");
            }
        }
    }
     public void UpdateLoanStatus(string accountNumber, UpdateLoanStatusCustomerDto updateLoanStatusCustomerDto){
        var updatedCustomer = _repository.GetbyAccountNumber(accountNumber);
        if (updatedCustomer != null){
            updatedCustomer.LoanPay = updateLoanStatusCustomerDto.LoanPay;
            var response = _repository.UpdateAccountstatus(updatedCustomer);
            if (response){
                Console.WriteLine("Account Status updated sucessfully");
            }else{
                Console.WriteLine("Account Status update failed");
            }
        }
    }
    public void DeleteCustomer(string accountNumber){
        var response = _repository.Delete(accountNumber);
        if (response){
            Console.WriteLine("Account Deletion sucessfully");
        }else{
            Console.WriteLine("Account Deletion failed");
        }
    }
    public string Check(string accountNumber){
        var customer = _repository.GetbyAccountNumber(accountNumber);
        if (customer != null){   
            Random rd = new Random();
            string newAccountNumber = $"{rd.Next(10000000, 99999999)}";
            return Check(newAccountNumber);
        }else{
            return accountNumber;
        }
    }
}