using OnlineBookStoreWebApi.Models;
using RBookingWebApi.DataContext;
using RBookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RBookingWebApi.DBL
{
    public class DatabaseService: IDatabaseService
    {
        private readonly RBookingWeApiDataContext dbcontext;
        public DatabaseService(RBookingWeApiDataContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        //get all Tables 
        public List<TableMD> GetAllTables()
        {
            var query = (from c in dbcontext.RTableTB
                         select new TableMD {
                         RTableId=c.RTableId,
                          Capacity=c.Capacity,
                          TableNumber=c.TableNumber
                         }).ToList();
            return query;
        }
        //GetTableStatus
        public List<TableMD> GetTableStatus()
        {
            List<TableMD> list = new List<TableMD>();
            var query = (from c in dbcontext.RTableTB
                         select new TableMD
                         {
                             RTableId = c.RTableId,
                             Capacity = c.Capacity,
                             TableNumber = c.TableNumber
                         }).ToList();
            foreach (var q in query)
            {
                var Status = dbcontext.ReservationTB.Where(x => x.RTableId == q.RTableId && x.OrderId == 0).FirstOrDefault();
                q.Status = Status != null ? true : false;
                list.Add(q);
            }
            return query;
        }
        //get table by id
        public List<TableMD> GetTableById(int Id)
        {
            var query = (from c in dbcontext.RTableTB
                         where c.RTableId==Id
                         select new TableMD
                         {
                             RTableId = c.RTableId,
                             Capacity = c.Capacity,
                             TableNumber = c.TableNumber
                         }).ToList();
            return query;
        }
        //Save And UPdate Table
        public String SaveAndUpdateTable(TableMD value)
        {
            string response = "";
            var CheckPresence = dbcontext.RTableTB.Where(x => x.RTableId == value.RTableId).FirstOrDefault();
            if (CheckPresence == null)
            {
                RTableTB rTableTB = new RTableTB();
                rTableTB.TableNumber = value.TableNumber;
                rTableTB.Capacity = value.Capacity;
               
                dbcontext.RTableTB.Add(rTableTB);
                dbcontext.SaveChanges();
                response = "Save Successfully.";
            }
            else {

                CheckPresence.TableNumber = value.TableNumber;
                CheckPresence.Capacity = value.Capacity;        
                dbcontext.SaveChanges();
                response = "Updated Successfully.";
            }
            return response;
            
        }
        //Delete Table
        public string DeleteTable(int id)
        {
            String response = "";
            var Query = dbcontext.RTableTB.Where(x => x.RTableId == id).FirstOrDefault();
            if (Query != null)
            {
                dbcontext.RTableTB.Remove(Query);
                dbcontext.SaveChanges();
                response = "Deleted Successfully";
            }
            return response;
        }


        #region/* Menu*/
        //get list of menu items 
        public List<MenuMD> GetMenuItems()
        {
            var query = (from c in dbcontext.MenuTB
                         select new MenuMD
                         {
                             MenuId = c.MenuId,
                             ItemName = c.ItemName,
                             Price = c.Price
                         }).ToList();
            return query;
        }
        //get Menu byId
        public List<MenuMD> GetMenuById(int Id)
        {
            var query = (from c in dbcontext.MenuTB
                         where c.MenuId==Id
                         select new MenuMD
                         {
                             MenuId = c.MenuId,
                             ItemName = c.ItemName,
                             Price = c.Price
                         }).ToList();
            return query;
        }

        //Save And Update Menu
        public String SaveAndUpdateMenu(MenuMD value)
        {
            string response = "";
            var CheckPresence = dbcontext.MenuTB.Where(x => x.MenuId == value.MenuId).FirstOrDefault();
            if (CheckPresence == null)
            {
                MenuTB menu = new MenuTB();
                menu.ItemName = value.ItemName;
                menu.Price = value.Price;
                dbcontext.MenuTB.Add(menu);
                dbcontext.SaveChanges();
                response = "Save Successfully.";
            }
            else
            {

                CheckPresence.ItemName = value.ItemName;
                CheckPresence.Price = value.Price;
                dbcontext.SaveChanges();
                response = "Updated Successfully.";
            }
            return response;

        }

        //Delete Menu
        public string DeleteMenu(int id)
        {
            String response = "";
            var Query = dbcontext.MenuTB.Where(x => x.MenuId == id).FirstOrDefault();
            if (Query != null)
            {
                dbcontext.MenuTB.Remove(Query);
                dbcontext.SaveChanges();
                response = "Deleted Successfully";
            }
            return response;
        }
        #endregion


        #region /*Reservations*/

        //get list of Reservations 
        public List<ReservationMD> GetAllReservations()
        {
            var query = (from c in dbcontext.ReservationTB
                         select new ReservationMD
                         {
                             ReservationId = c.ReservationId,
                             Quantity = c.Quantity,
                             Price = c.Price,
                             MenuId = c.MenuId,
                             RTableId=c.RTableId,
                             OrderId=c.OrderId

                         }).ToList();
            return query;
        }
        //get recent reservations
        public List<ReservationMD> GetRecentReservations()
        {
            List<ReservationMD> list = new List<ReservationMD>();
            var query = (from c in dbcontext.ReservationTB
                         join t in dbcontext.RTableTB on c.RTableId equals t.RTableId
                         
                         where c.OrderId==0
                         group c by c.RTableId into g
                         select new ReservationMD
                         {
                             RTableId = g.Key,  
                         }).ToList();
            foreach (var q in query)
            {
                var QueryInfo = (from c in dbcontext.ReservationTB
                                 join u in dbcontext.UsersTB on c.UserNo equals u.UserNo
                                 join t in dbcontext.RTableTB on c.RTableId equals t.RTableId
                                 where c.RTableId == q.RTableId && c.OrderId==0  select new {t.TableNumber, c.RTableId, c.UserNo, u.FirstName, u.LastName }).ToList();

                q.TableNumber = QueryInfo.Select(x => x.TableNumber).FirstOrDefault();
                q.User= QueryInfo.Select(x => x.FirstName).FirstOrDefault();
                list.Add(q);
            }
            return list;
        }
        public List<ReservationMD> GetReservationWithTable(int TableId)
        {
            var query = (from c in dbcontext.ReservationTB
                         join i in dbcontext.MenuTB on c.MenuId equals i.MenuId
                         where c.RTableId==TableId && c.OrderId==0
                         select new ReservationMD
                         {
                             ReservationId = c.ReservationId,
                             Quantity = c.Quantity,
                             Price = c.Price,
                             MenuId = c.MenuId,
                             RTableId = c.RTableId,
                             OrderId = c.OrderId,
                             ItemName=i.ItemName,
                             UserCapacity=c.UserCapacity

                         }).ToList();
            return query;
        }
        //get reservation by id 
        public List<ReservationMD> GetReservationById(int id)
        {
            var query = (from c in dbcontext.ReservationTB
                         where c.ReservationId==id
                         select new ReservationMD
                         {
                             ReservationId = c.ReservationId,
                             Quantity = c.Quantity,
                             Price = c.Price,
                             MenuId = c.MenuId,
                             RTableId = c.RTableId,
                             OrderId=c.OrderId

                         }).ToList();
            return query;
        }
        //save Reservation
        //Save And Update Reservation
        public String SaveAndUpdateReservation(ReservationMD value)
        {
            string response = "";
            var CheckPresence = dbcontext.ReservationTB.Where(x => x.ReservationId == value.ReservationId).FirstOrDefault();
            if (CheckPresence == null)
            {
                ReservationTB reservationTB = new ReservationTB();
                reservationTB.Quantity = value.Quantity;
                reservationTB.Price = dbcontext.MenuTB.Where(x => x.MenuId == value.MenuId).Select(x => x.Price).FirstOrDefault();
                reservationTB.MenuId = value.MenuId;
                reservationTB.RTableId = value.RTableId;
                reservationTB.OrderId = 0;
                reservationTB.UserCapacity = value.UserCapacity;
                reservationTB.UserNo = value.UserNo;
                dbcontext.ReservationTB.Add(reservationTB);
                dbcontext.SaveChanges();
                response = "Save Successfully.";
            }
            else
            {

                CheckPresence.MenuId = value.MenuId;
                CheckPresence.Price = dbcontext.MenuTB.Where(x => x.MenuId == value.MenuId).Select(x => x.Price).FirstOrDefault();
                CheckPresence.RTableId = value.RTableId;
                CheckPresence.Quantity = value.Quantity;
                CheckPresence.UserNo = value.UserNo;
                CheckPresence.UserCapacity = value.UserCapacity;
                dbcontext.SaveChanges();
                response = "Updated Successfully.";
            }
            return response;

        }
        //Delete Reservation
        public string DeleteReservation(int id)
        {
            String response = "";
           
        var Query = dbcontext.ReservationTB.Where(x => x.ReservationId == id).FirstOrDefault();
        if (Query != null)
                    {
                        dbcontext.ReservationTB.Remove(Query);
                        dbcontext.SaveChanges();
                        response = "Deleted Successfully";
                    }
            return response;
        }
        public string CancelReservation(int id,int UserNo)
        {
            String response = "";
            var GetReserverbyTable = dbcontext.ReservationTB.Where(x => x.RTableId == id && x.UserNo==UserNo).ToList();
            if (GetReserverbyTable.Count > 0)
            {
                foreach (var q in GetReserverbyTable)
                {
                    var Query = dbcontext.ReservationTB.Where(x => x.ReservationId == q.ReservationId).FirstOrDefault();
                    if (Query != null)
                    {
                        dbcontext.ReservationTB.Remove(Query);
                        dbcontext.SaveChanges();
                        response = "Deleted Successfully";
                    }
                }
            }
            else
            {
                response = "You are not Authorized to Delete";
            }
            
            
            return response;
        }
        public string CancelReservationAdmin(int id)
        {
            String response = "";
            var GetReserverbyTable = dbcontext.ReservationTB.Where(x => x.RTableId == id).ToList();
            if (GetReserverbyTable.Count > 0)
            {
                foreach (var q in GetReserverbyTable)
                {
                    var Query = dbcontext.ReservationTB.Where(x => x.ReservationId == q.ReservationId).FirstOrDefault();
                    if (Query != null)
                    {
                        dbcontext.ReservationTB.Remove(Query);
                        dbcontext.SaveChanges();
                        response = "Deleted Successfully";
                    }
                }
            }
            else
            {
                response = "You are not Authorized to Delete";
            }


            return response;
        }
        public String BookReservation(ReservationMD value)
        {
            string response = "";          
                ReservationTB reservationTB = new ReservationTB();
                reservationTB.Quantity = value.Quantity;
                reservationTB.Price = dbcontext.MenuTB.Where(x => x.MenuId == value.MenuId).Select(x => x.Price).FirstOrDefault();
                reservationTB.MenuId = 0;
                reservationTB.RTableId = value.RTableId;
                reservationTB.OrderId = 0;
                reservationTB.UserNo = value.UserNo;
                dbcontext.ReservationTB.Add(reservationTB);
                dbcontext.SaveChanges();
                response = "Save Successfully.";
            return response;

        }
        #endregion


        #region /*Orders*/
        //get list of Orders 
        public List<OrderMD> GetAllOrders()
        {
            var query = (from c in dbcontext.OrderTB
                         join t in dbcontext.RTableTB on c.RTableId equals t.RTableId
                         join u in dbcontext.UsersTB on c.UserNo equals u.UserNo
                         select new OrderMD
                         {
                             RTableId = c.RTableId,
                             CreatedBy = c.CreatedBy,
                             OrderId = c.OrderId,
                             DateTime = c.DateTime,
                             TableNumber = t.TableNumber,
                             User = u.FirstName + "" + u.LastName,
                             CartList = (from d in dbcontext.OrderDetailTB join n in dbcontext.MenuTB on d.MenuId equals n.MenuId where d.OrderId == c.OrderId select new OrderDetailMD { ItemName = n.ItemName, OrderDetailsId = d.OrderDetailsId, Price = d.Price, Quantity = d.Quantity, MenuId = d.MenuId }).ToList()

                         }).ToList();
            return query;
        }
        //get order by id 
        public List<OrderMD> GetOrderById(int id)
        {
            var query = (from c in dbcontext.OrderTB
                         join u in dbcontext.UsersTB on c.UserNo equals u.UserNo
                         where c.OrderId==id
                         select new OrderMD
                         {
                             RTableId = c.RTableId,
                             CreatedBy = c.CreatedBy,
                             OrderId = c.OrderId,
                             DateTime = c.DateTime,
                             TotalAmount=c.TotalAmount,
                             User = u.FirstName + "" + u.LastName,
                             CartList = (from d in dbcontext.OrderDetailTB join n in dbcontext.MenuTB on d.MenuId equals n.MenuId where d.OrderId == id select new OrderDetailMD { ItemName = n.ItemName,  OrderDetailsId = d.OrderDetailsId, Price = d.Price, Quantity = d.Quantity, MenuId = d.MenuId }).ToList()

                         }).ToList();
            return query;
        }

        //Save And Update Menu
        public String SaveAndUpdateOrder(OrderMD value)
        {
            string response = "";
            var CheckPresence = dbcontext.OrderTB.Where(x => x.OrderId == value.OrderId).FirstOrDefault();
            if (CheckPresence == null)
            {
                OrderTB orderTB = new OrderTB();
                orderTB.CreatedBy = 1;
                orderTB.DateTime = DateTime.Now;
                orderTB.RTableId = value.RTableId;
                orderTB.UserNo = value.UserNo;
                orderTB.TotalAmount = GetTotalAmount(value.CartList);
                dbcontext.OrderTB.Add(orderTB);
                dbcontext.SaveChanges();
                //Save Order Details
                double TotalAmount = 0;
                foreach (var q in value.CartList)
                {
                    OrderDetailTB orderDetailTB = new OrderDetailTB();
                    orderDetailTB.OrderId = orderTB.OrderId;
                    orderDetailTB.Price = q.Price;
                    orderDetailTB.Quantity = q.Quantity;
                    orderDetailTB.MenuId = q.MenuId;
                    dbcontext.OrderDetailTB.Add(orderDetailTB);
                    dbcontext.SaveChanges();
                    
                }

                //Update Status of Table
                var RerserveTable = dbcontext.ReservationTB.Where(x => x.RTableId == value.RTableId && x.OrderId==0).ToList();
                foreach (var d in RerserveTable)
                {
                    var Update = dbcontext.ReservationTB.Where(x => x.ReservationId == d.ReservationId).FirstOrDefault();
                    Update.OrderId = orderTB.OrderId;
                    dbcontext.SaveChanges();
                }
                response = orderTB.OrderId.ToString();
            }
            else
            {

                CheckPresence.RTableId = value.RTableId;
                CheckPresence.TotalAmount = value.TotalAmount;              
                dbcontext.SaveChanges();

                //var Delete existing 
                var PastDetails = dbcontext.OrderDetailTB.Where(x => x.OrderId == value.OrderId).ToList();
                foreach (var d in PastDetails)
                {
                    var Query = dbcontext.OrderDetailTB.Where(x => x.OrderDetailsId == d.OrderDetailsId).FirstOrDefault();
                    dbcontext.OrderDetailTB.Remove(Query);
                    dbcontext.SaveChanges();
                }

                //Save Order Details
                foreach (var q in value.CartList)
                {
                    OrderDetailTB orderDetailTB = new OrderDetailTB();
                    orderDetailTB.OrderId = CheckPresence.OrderId;
                    orderDetailTB.Price = q.Price;
                    orderDetailTB.Quantity = q.Quantity;
                    orderDetailTB.MenuId = q.MenuId;
                    dbcontext.OrderDetailTB.Add(orderDetailTB);
                    dbcontext.SaveChanges();
                }
                response = value.OrderId.ToString();
            }
            return response;

        }

        private double GetTotalAmount(IEnumerable<OrderDetailMD> cartList)
        {
            double TotalAmount = 0;
            foreach (var q in cartList)
            {
                TotalAmount += q.Price;
            }
            return TotalAmount;
        }

        //Delete Reservation
        public string DeleteOrder(int id)
        {
            String response = "";
            var Query = dbcontext.OrderTB.Where(x => x.OrderId == id).FirstOrDefault();
            if (Query != null)
            {
                dbcontext.OrderTB.Remove(Query);
                dbcontext.SaveChanges();
                response = "Deleted Successfully";
            }
            //var Delete existing 
            var PastDetails = dbcontext.OrderDetailTB.Where(x => x.OrderId == id).ToList();
            foreach (var d in PastDetails)
            {
                var QueryDetails = dbcontext.OrderDetailTB.Where(x => x.OrderDetailsId == d.OrderDetailsId).FirstOrDefault();
                dbcontext.OrderDetailTB.Remove(QueryDetails);
                dbcontext.SaveChanges();
            }
            return response;
        }
        #endregion


        public UserMD AuthenticateUser(LoginMD login)
        {
            UserMD user = new UserMD();
            String EncriptedPassword = Encrypt(login.Password);
            var query = dbcontext.UsersTB.Where(x => x.Email == login.Email && x.Password == EncriptedPassword).FirstOrDefault();
            if (query != null)
            {
                user.Email = query.Email;
                user.UserNo = query.UserNo;
                user.Role = query.Role;

            }

            return user;
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}
