using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FunBooksAndVideos.Models;

namespace FunBooksAndVideos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {

        // POST: OrderController/Create
        [HttpPost]
        public string Order([FromBody] Order order)
        {
            try
            {
                Membership membership = new Membership();
                Shipping shipping = new Shipping();
                PurchaseOrder purchaseOrder = new PurchaseOrder();

                string results = "";

                int poId = order.POId;
                decimal total = order.Total;
                int customerId = order.CustomerId;
                string[] itemLines = order.ItemLines;

                int lineLength = itemLines.Length;

                if(poId <= 0 || total <= 0 || customerId <= 0 || lineLength == 0)
                {
                    return "Bad request";
                }

                string line;
                bool isMembership = false;
                for(int i = 0; i < lineLength; i++)
                {
                    isMembership = false;

                    line = itemLines[i];
                    if(line == "Book Club Membership")
                    {
                        //Activate Book Club Membership
                        membership.ActivateBook(customerId);
                        isMembership = true;
                        results += "Activate Book Club Membership;";
                    }
                    if(line == "Video Club Membership")
                    {
                        //Activate Video Club Membership
                        membership.ActivateVideo(customerId);
                        isMembership = true;
                        results += "Activate Video Club Membership;";
                    }

                    if(!isMembership)
                    {
                        if(line.IndexOf("Book") == 0)
                        {
                            //Generate shipping slip
                            shipping.ShippingSlip(poId, customerId, line);
                            results += "Generate shipping slip;";
                        }
                        purchaseOrder.Purchase(poId, customerId, line);
                        results += "Purchase order;";
                    }
                }

                return results;
            }
            catch
            {
                return "Request failed";
            }
        }
    }


}
