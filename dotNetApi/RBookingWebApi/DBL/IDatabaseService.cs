using OnlineBookStoreWebApi.Models;
using RBookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.DBL
{
    public interface IDatabaseService
    {
        List<TableMD> GetAllTables();
        List<TableMD> GetTableById(int Id);
        String SaveAndUpdateTable(TableMD value);
        string DeleteTable(int id);
        List<MenuMD> GetMenuItems();
        List<MenuMD> GetMenuById(int Id);
        String SaveAndUpdateMenu(MenuMD value);
        string DeleteMenu(int id);
        List<TableMD> GetTableStatus();
        List<ReservationMD> GetAllReservations();
        List<ReservationMD> GetReservationById(int id);
        String SaveAndUpdateReservation(ReservationMD value);
        string DeleteReservation(int id);
        string CancelReservation(int id, int UserNo);
        string CancelReservationAdmin(int id);
        List<OrderMD> GetAllOrders();
        List<OrderMD> GetOrderById(int id);
        String SaveAndUpdateOrder(OrderMD value);
        string DeleteOrder(int id);
        List<ReservationMD> GetReservationWithTable(int TableId);
        List<ReservationMD> GetRecentReservations();
        UserMD AuthenticateUser(LoginMD login);
        String BookReservation(ReservationMD value);
    }
}
