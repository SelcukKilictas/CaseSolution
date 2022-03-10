using CaseSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseSolution.Data
{
    public class Repository
    {
        private readonly TestContext _testContext;
       //context için dependecy inection gerçekleştirildi.
        public Repository(TestContext testContext)
        {
            _testContext = testContext;
        }
        /// <summary>
        /// outo mapper kullanılabilir!
        /// </summary>
        /// <returns></returns>
        public List<OrderVM> getOrder(string dateStart, string dateFinish)
        {
            DateTime startTime, endTime;
            DateTime.TryParse(dateStart, out startTime);
            DateTime.TryParse(dateFinish, out endTime);

            List<Sti> orders = new List<Sti>();
            List<OrderVM> returnOrders = new List<OrderVM>();
            orders = _testContext.Stis.Where(x => x.Tarih > Convert.ToInt32((startTime).ToOADate())
            && x.Tarih < Convert.ToInt32((endTime).ToOADate())).ToList();
            decimal stok = 0;

           

            if (orders == null)
            {
                return null;
            }
            foreach (var order in orders)
            {
                var orderVmData = new OrderVM();
                orderVmData.SiraNO = order.Id;
                orderVmData.IslemTur = order.IslemTur == 0 ? "Giris" : "Cikis";
                orderVmData.EvrakNo = order.EvrakNo;

                if (orderVmData.IslemTur == "Giris")
                {
                    orderVmData.GirisMiktar = order.Miktar;
                    orderVmData.CikisMiktar = 0;
                }
                else
                {
                    orderVmData.GirisMiktar = 0;
                    orderVmData.CikisMiktar = order.Miktar;
                }


               
                //int datatime = order.Tarih;
                //var dateTimeDeneme = new DateTime();
                //orderVmData.Tarih =DateTime.ParseExact(datatime.ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                
               
                DateTime dt = DateTime.FromOADate(order.Tarih);
                orderVmData.Tarih = dt;
                
                if (orderVmData.IslemTur == "Giris")
                {
                    stok += order.Miktar;
                    orderVmData.StokMiktar = stok;
                }
                else
                {
                    stok -= order.Miktar;
                    orderVmData.StokMiktar = stok;
                }

                returnOrders.Add(orderVmData);


            }
            return returnOrders;
        }
    }
}
