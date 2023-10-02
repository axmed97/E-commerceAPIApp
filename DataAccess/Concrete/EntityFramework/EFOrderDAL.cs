using Core.DataAccess.EntitFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFOrderDAL : EFRepositoryBase<Order, AppDbContext>, IOrderDAL
    {
        public void AddRange(int userId, List<Order> orders)
        {
            using var context = new AppDbContext();
            var result = orders.Select(x => { x.UserId = userId; x.CreatedDate = DateTime.Now; x.OrderNumber = Guid.NewGuid().ToString().Substring(0, 18); x.OrderEnum = OrderEnum.OnPending; return x; }).ToList();

            context.Orders.AddRange(result);
            context.SaveChanges();
        }

        public List<Order> GetOrderByUser(int userId)
        {
            using var context = new AppDbContext();
            var result = context.Orders
                .Include(x => x.Product).Where(x => x.UserId == userId).ToList();

            return result;
        }
    }
}
