using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CreditCard.Models;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Data;

namespace CreditCard.Controllers
{
    public class ValidateController : ApiController
    {
        ResultModel rm = new ResultModel();

        [HttpGet]
        public ResultModel CheckCard(string cardnumber, string expirydate)
        {

            rm.validatation(cardnumber, expirydate);

            if (rm.result == "Valid") //If It's invalid, skip checking db to see if exists
            {
                try
                {
                    using (CreditCardEntities cce = new CreditCardEntities())
                    {
                        
                        var exists = cce.CheckCreditCardIfExists(cardnumber);
                        if (exists.ToString() == "0")
                        {
                            rm.result = "Does not exist";
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return rm;
        }
    }
}
