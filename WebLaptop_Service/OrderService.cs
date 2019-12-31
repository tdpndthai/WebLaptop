using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLaptop_Data.Infrastructure;
using WebLaptop_Data.Repositories;
using WebLaptop_Model.Models;

namespace WebLaptop_Service
{
    public interface IOrderService
    {
        bool CreateOrder(Order order,List<OrderDetail> orderDetails);
    }
    public class OrderService:IOrderService
    {
        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailRepository;
        IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository,IUnitOfWork unitOfWork,IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
        }
        public bool CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.ID;
                    _orderDetailRepository.Add(orderDetail);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
