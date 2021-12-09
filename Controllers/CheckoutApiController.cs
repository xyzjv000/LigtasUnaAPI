using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;
using Stripe.Checkout;
namespace ligtasUnaAPI.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class CheckoutApiController : ControllerBase
    {
        public CheckoutApiController()
        {
            StripeConfiguration.ApiKey = "sk_test_51K11lAFbFEwbMsJJZCBdPE16SOOIrz6jzGbVPZxAg98Kwd0jaJb7pSY9trz0h0dlAM7L8jGJSn9uuyk2Rbzdwjm400oWSdXb4y";
        }
        public ActionResult Get()
        {
            StripeConfiguration.ApiKey = "sk_test_51K11lAFbFEwbMsJJZCBdPE16SOOIrz6jzGbVPZxAg98Kwd0jaJb7pSY9trz0h0dlAM7L8jGJSn9uuyk2Rbzdwjm400oWSdXb4y";
            
            var options = new PaymentIntentCreateOptions
            {
                Amount = 24900,
                Currency = "PHP",
                PaymentMethodTypes = new List<string> {
                "card",
              },
            };

            var service = new PaymentIntentService();
            var intent = service.Create(options);
            return Ok(new { client_secret = intent.ClientSecret });
        }

        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession()
        {
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
            {
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = 100,
                    Currency = "php",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                         Name = "LigtasUna Subscription",
                        },

                    },
                    Quantity = 1,
                  },
                },
                Mode = "payment",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }


    }
}
