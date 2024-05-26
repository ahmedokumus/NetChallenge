using Application.Utilities.Results.Abstract;
using Application.ViewModels.Order;
using Domain.Entities;

namespace Application.Services;

public interface IOrderService
{
    IDataResult<List<Order>> GetAll();
    IResult Create(VmCreateOrder vmCreateOrder);

}