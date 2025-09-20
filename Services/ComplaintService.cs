using BankApp.Context;
using BankApp.Entities;
using BankApp.Models.DTOs;
using BankApp.Repositories;
namespace BankApp.Services;
public class ComplaintService{
    ComplaintRepository _repository;
    CustomerRepository customerRepository;
    CustomerService _customerService;
    StaffRepository staffRepository;
    StaffService _staffService;
    public ComplaintService(ComplaintRepository repository, BankAppDbContext dbContext){
        _repository = repository;
        customerRepository = new CustomerRepository(dbContext);
        _customerService = new CustomerService(customerRepository);
        staffRepository = new StaffRepository(dbContext);
        _staffService = new StaffService(staffRepository);
    }
    public void Create(CreateComplaintDto createComplaintDto){
        var complaint = new Complaint(){
            AccountNumber = createComplaintDto.AccountNumber,
            Description = createComplaintDto.Description,
            };
        var response = _repository.Create(complaint);
        if(response){
            Console.WriteLine("Complaint Lodged Sucessfully");
        }
        else{
            Console.WriteLine("Error In Lodging Complaint");
        }
    }
    public List<GetComplaintDto> List(string accountNumber){
        var complaints = _repository.List(accountNumber);
        if (complaints != null){
            return complaints.Select(complait => new GetComplaintDto{
                Description = complait.Description,
                AccountNumber =complait.AccountNumber
            }).ToList();
        }else{
            Console.WriteLine($"No Complaints from {accountNumber}");
            return null;
        }        
    }
    public List<GetComplaintDto> ListAll(){
        var complaints = _repository.ListAll();
        if (complaints != null){
            return complaints.Select(complait => new GetComplaintDto{
                Description = complait.Description,
                AccountNumber =complait.AccountNumber
            }).ToList();
        }else{
            Console.WriteLine($"No Complaints from Customers Or Staffs");
            return null;
        }
    }
    public string CheckStaffCustomer(string value){
        var checkStaff = _staffService.Find(value);
        var checkCustomer = _customerService.Find1(value);
        if(checkStaff != null || checkCustomer != null){
            return value;
        }else{
            Console.WriteLine("An Error Occured!. Enter A Registered Account Number / Email Address To Continue.");
            return null;
        }
    }
}