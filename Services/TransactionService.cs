using BankApp.Context;
using BankApp.Entities;
using BankApp.Models.DTOs;
using BankApp.Repositories;
namespace BankApp.Services;
public class TransactionService{
    private TransactionRepository _repository;
    private CustomerRepository customerRepository;
    private CustomerService _service;
    public TransactionService(TransactionRepository repository, BankAppDbContext dbContext){
        _repository = repository;
        customerRepository = new CustomerRepository(dbContext);
        _service = new CustomerService(customerRepository);
    }
    public void Credit(CreateTransactionDto createTransactionDto, GetCustomerDto customerDto, decimal amount){
        var updatedCustomer = _service.Find1(customerDto.AccountNumber);
        var transaction = new Transaction(){
            TransactionId = createTransactionDto.TransactionId,
            TransactionType = createTransactionDto.TransactionType,
            TransactionDate = createTransactionDto.TransactionDate,
            Amount = createTransactionDto.Amount,
            Description = createTransactionDto.Description,
            AccountNumber = createTransactionDto.AccountNumber,
            };
        var updateBalanceCustomerDto = new UpdateBalanceCustomerDto(){
            Balance = customerDto.Balance + amount,
            };
        _service.UpdateBalance(customerDto.AccountNumber, updateBalanceCustomerDto);
        var response = _repository.Create(transaction);
        if(response){
            Console.WriteLine("Credit Transaction Sucessful");
        }
        else{
            Console.WriteLine("Credit Transaction Not Sucessful");
        }
    }
    public void Debit(CreateTransactionDto createTransactionDto, GetCustomerDto customerDto, decimal charges, decimal amount){
        var updatedCustomer = _service.Find1(customerDto.AccountNumber);
        var transaction = new Transaction(){
            TransactionId = createTransactionDto.TransactionId,
            TransactionType = createTransactionDto.TransactionType,
            TransactionDate = createTransactionDto.TransactionDate,
            Amount = createTransactionDto.Amount,
            Description = createTransactionDto.Description,
            AccountNumber = createTransactionDto.AccountNumber,
            };
        var updateBalanceCustomerDto = new UpdateBalanceCustomerDto(){
            Balance = customerDto.Balance - (amount + charges),
            };
        _service.UpdateBalance(customerDto.AccountNumber, updateBalanceCustomerDto);
        var response = _repository.Create(transaction);
        if(response){
            Console.WriteLine("Debit Transaction Sucessful");
        }else{
            Console.WriteLine("Debit Transaction Not Sucessful");
        }
    }
    public void Transfer(CreateTransactionDto createsenderTransactionDto, CreateTransactionDto createreceiverTransactionDto, GetCustomerDto customerDto, GetCustomerDto transferCustomer, decimal charges){
        var sendCustomer = _service.Find1(customerDto.AccountNumber);
        var receiveCustomer = _service.Find1(transferCustomer.AccountNumber);
        var sendtransaction = new Transaction(){
            TransactionId = createsenderTransactionDto.TransactionId,
            TransactionType = createsenderTransactionDto.TransactionType,
            TransactionDate = createsenderTransactionDto.TransactionDate,
            Amount = createsenderTransactionDto.Amount,
            Description = createsenderTransactionDto.Description,
            AccountNumber = createsenderTransactionDto.AccountNumber,
            };
        var receivetransaction = new Transaction(){
            TransactionId = createreceiverTransactionDto.TransactionId,
            TransactionType = createreceiverTransactionDto.TransactionType,
            TransactionDate = createreceiverTransactionDto.TransactionDate,
            Amount = createreceiverTransactionDto.Amount,
            Description = createreceiverTransactionDto.Description,
            AccountNumber = createreceiverTransactionDto.AccountNumber,
            };
        var sendCustomerBalance = new UpdateBalanceCustomerDto(){
            Balance = sendCustomer.Balance - (createsenderTransactionDto.Amount + charges)
        };
        var receiveCustomerBalance = new UpdateBalanceCustomerDto(){
            Balance = receiveCustomer.Balance + createsenderTransactionDto.Amount
        };
        _service.UpdateBalance(sendCustomer.AccountNumber, sendCustomerBalance);
        _service.UpdateBalance(receiveCustomer.AccountNumber, receiveCustomerBalance);
        var response = _repository.Create(sendtransaction);
        var response2 = _repository.Create(receivetransaction);
        if(response && response2){
            Console.WriteLine("Transfer Transaction Sucessful");
        }else{
            Console.WriteLine("Transfer Transaction Not Sucessful");
        }
    } 
    public List<GetTransactionDto> 
    GetAll(string acccountNumber){
        var transactions = _repository.List(acccountNumber);
        return transactions.Select(transaction => new GetTransactionDto{
            TransactionId = transaction.TransactionId,
            TransactionDate = transaction.TransactionDate,
            TransactionType = transaction.TransactionType,
            Description = transaction.Description,
            Amount = transaction.Amount,
            AccountNumber =transaction.AccountNumber
        }).ToList();        
    }
}