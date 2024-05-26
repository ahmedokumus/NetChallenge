using Application.Repositories.CompanyRepo;
using Application.Repositories.OrderRepo;
using Application.Repositories.ProductRepo;
using Application.Services;
using Application.Utilities.Messages;
using Application.Utilities.Results.Abstract;
using Application.Utilities.Results.Concrete;
using Application.ViewModels.Order;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Services;

public class OrderService : IOrderService
{
    private readonly IOrderReadRepo _orderReadRepo;
    private readonly IOrderWriteRepo _orderWriteRepo;
    private readonly ICompanyReadRepo _companyReadRepo;
    private readonly IProductReadRepo _productReadRepo;

    public OrderService(IOrderReadRepo orderReadRepo, IOrderWriteRepo orderWriteRepo, ICompanyReadRepo companyReadRepo, IProductReadRepo productReadRepo)
    {
        _orderReadRepo = orderReadRepo;
        _orderWriteRepo = orderWriteRepo;
        _companyReadRepo = companyReadRepo;
        _productReadRepo = productReadRepo;
    }

    public IDataResult<List<Order>> GetAll()
    {
        if (DateTime.Now.Hour == 01)
        {
            return new ErrorDataResult<List<Order>>(Messages.MaintenanceTime);
        }

        return new SuccessDataResult<List<Order>>(_orderReadRepo.GetAll(), Messages.OrdersListed);
    }

    public IResult Create(VmCreateOrder vmCreateOrder)
    {
        var product = _productReadRepo.GetById(vmCreateOrder.ProductId);
        if (product == null)
        {
            return new ErrorResult(Messages.ProductNotFound);
        }

        var company = _companyReadRepo.GetById(product.CompanyId);
        if (company == null || company.Status == false)
        {
            return new ErrorResult(Messages.CompanyNotApproved);
        }

        var currentTime = DateTime.Now.TimeOfDay;
        if (currentTime < company.OrderPermitStartTime || currentTime > company.OrderPermitFinishTime)
        {
            return new ErrorResult(Messages.OutOfLeaveTime);
        }

        Order order = new()
        {
            CustomerName = vmCreateOrder.CustomerName,
            OrderTime = currentTime,
            ProductId = vmCreateOrder.ProductId,
            Product = product
        };

        _orderWriteRepo.Add(order);
        return new SuccessResult(Messages.OrderCreated);
    }
}