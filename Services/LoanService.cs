using BankApp.Context;
using BankApp.Entities;
using BankApp.Models.DTOs;
using BankApp.Models.Enums;
using BankApp.Repositories;
namespace BankApp.Services;
public class LoanService{
    private readonly LoanRepository _repository;
    private readonly CustomerService _cusservice;
    private readonly TransactionService _transService;
    private readonly CustomerRepository customerRepository;
    private readonly TransactionRepository transactionRepository;
    public LoanService(LoanRepository repository, BankAppDbContext dbContext){
        _repository = repository;
        customerRepository = new CustomerRepository(dbContext);
        _cusservice = new CustomerService(customerRepository);
        transactionRepository = new TransactionRepository(dbContext);
        _transService = new TransactionService(transactionRepository, dbContext);
    }
    public void CreateLoan(CreateTransactionDto createTransactionDto, GetCustomerDto customerDto, CreateLoanDto createLoanDto){
        if(customerDto.LoanPay == LoanPay.Paid){
            var updatedCustomer = _cusservice.Find1(customerDto.AccountNumber);
            var transaction = new CreateTransactionDto(){
                TransactionId = createTransactionDto.TransactionId,
                TransactionType = createTransactionDto.TransactionType,
                TransactionDate = createTransactionDto.TransactionDate,
                Amount = createLoanDto.Amount,
                Description = createLoanDto.Description,
                AccountNumber = createTransactionDto.AccountNumber
                };
            var loan = new Loan(){
                LoanId = createLoanDto.LoanId,
                Loans = createLoanDto.Loans,
                LoanDate = createLoanDto.LoanDate,
                LoanPay = createLoanDto.LoanPay,
                Interest = createLoanDto.Interest,
                Amount = createLoanDto.Amount,
                AmountPaid = createLoanDto.AmountPaid,
                Description = createLoanDto.Description,
                AccountNumber = customerDto.AccountNumber
            };
            var updateBalanceCustomerDto = new UpdateBalanceCustomerDto(){
                Balance = customerDto.Balance + createLoanDto.Amount
            };
            var updateLoanCustomerDto = new UpdateLoanStatusCustomerDto(){
                LoanPay = LoanPay.NotPaid
            };
            _transService.Credit(createTransactionDto, customerDto, createLoanDto.Amount);
            _cusservice.UpdateBalance(customerDto.AccountNumber, updateBalanceCustomerDto);
            _cusservice.UpdateLoanStatus(customerDto.AccountNumber, updateLoanCustomerDto);
            var response = _repository.Create(loan);
            if(response){
                Console.WriteLine("Loan Sucessful");
            }
            else{
                Console.WriteLine("Firstly Pay Unpaid Loans.");
            }
        }else{
            
        }
    }
    public void UpdateLoan(CreateTransactionDto createTransactionDto, GetCustomerDto customerDto, decimal charges){
        var updatedCustomer = _cusservice.Find1(customerDto.AccountNumber);
        var updateLoan = _repository.GetbyStatus(customerDto.LoanPay,customerDto.AccountNumber);
        if (updateLoan != null){
            var transaction = new CreateTransactionDto(){
                TransactionId = createTransactionDto.TransactionId,
                TransactionType = createTransactionDto.TransactionType,
                TransactionDate = createTransactionDto.TransactionDate,
                Amount = createTransactionDto.Amount,
                Description = createTransactionDto.Description,
                AccountNumber = createTransactionDto.AccountNumber,
                };
            updateLoan.AmountPaid += createTransactionDto.Amount;
            decimal Interest = updateLoan.Amount + ((updateLoan.Amount * updateLoan.Interest)/ 100);
            if (customerDto.Balance >= createTransactionDto.Amount){
                updateLoan.LoanPay = updateLoan.LoanPay;
                if(updateLoan.AmountPaid > 0 && updateLoan.AmountPaid < Interest){
                    updateLoan.LoanPay = LoanPay.Pending;
                }else if(updateLoan.AmountPaid >= Interest){
                    updateLoan.LoanPay = LoanPay.Paid;
                }
                var updateBalanceCustomerDto = new UpdateBalanceCustomerDto(){
                Balance = customerDto.Balance - (createTransactionDto.Amount + charges),
                };
                var updateLoanCustomerDto = new UpdateLoanStatusCustomerDto(){
                    LoanPay = updateLoan.LoanPay
                };
                var updateLoanAmountPaidDto = new UpdateLoanDto(){
                    LoanPay = updateLoan.LoanPay,
                    AmountPaid = updateLoan.AmountPaid
                };
                _transService.Debit(transaction, customerDto, charges, createTransactionDto.Amount);
                _cusservice.UpdateBalance(customerDto.AccountNumber, updateBalanceCustomerDto);
                _cusservice.UpdateLoanStatus(customerDto.AccountNumber, updateLoanCustomerDto);
                var response = _repository.Update(updateLoan);
                if(response ){
                    Console.WriteLine("Loan Payment Sucessful");
                }else{
                    Console.WriteLine("Loan Payment Not Sucessful");
                }
            }else{
                Console.WriteLine("Insuficient Funds!");
            }
        }
    }
    public decimal CheckAmountLeft(GetCustomerDto customerDto){
        var loans = Find(customerDto.LoanPay, customerDto.AccountNumber);
        decimal amountLeft = 0;
        if (loans == null){
            return amountLeft;
        }else{
            amountLeft = (loans.Amount + (loans.Amount * loans.Interest/100)) - loans.AmountPaid;
            return amountLeft;
        }
    }
    public GetLoanDto Find(LoanPay loanPay, string accountNumber){
        var loan = _repository.GetbyStatus(loanPay, accountNumber);
        if (loan != null){
                return new GetLoanDto(){
                AccountNumber =  loan.AccountNumber,
                LoanPay = loan.LoanPay,
                LoanDate = loan.LoanDate,
                LoanId = loan.LoanId,
                Loans = loan.Loans,
                Amount = loan.Amount,
                AmountPaid = loan.AmountPaid,
                Interest = loan.Interest,
                Description = loan.Description
            };
        }
        return null;
    }
    public List<GetLoanDto> GetAll(string accountNumber){
        var loans = _repository.List(accountNumber);
        return loans.Select(loan => new GetLoanDto{
            LoanId = loan.LoanId,
            LoanDate = loan.LoanDate,
            LoanPay = loan.LoanPay,
            Loans = loan.Loans,
            Interest = loan.Interest,
            AmountPaid = loan.AmountPaid,
            Description = loan.Description,
            Amount = loan.Amount,
            AccountNumber = loan.AccountNumber
        }).ToList();        
    }
    public List<GetLoanDto> ListAll(){
        var loans = _repository.ListAll();
        return loans.Select(loan => new GetLoanDto{
            LoanId = loan.LoanId,
            LoanDate = loan.LoanDate,
            LoanPay = loan.LoanPay,
            Loans = loan.Loans,
            Interest = loan.Interest,
            AmountPaid = loan.AmountPaid,
            Description = loan.Description,
            Amount = loan.Amount,
            AccountNumber = loan.AccountNumber
        }).ToList();        
    }
}