using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class CustomerBL
    {
        public Customer GetCustomerDetails(int id)
        {
            Customer customerDetail = new Customer()
            {
                Id = id,
                Name = "John Doe",
                Email = "john@example.com",
                PhoneNumber = "123-456-7890"
            };
            return customerDetail;
        }
    }
}