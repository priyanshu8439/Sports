
namespace Sports
{
    using System;
    using System.Collections.Generic;

    public partial class Cart
    {
        public string CarId { get; set; }
        public string ProId { get; set; }
        public string CusId { get; set; }
        public string Quantity { get; set; }

        public virtual Customer_info Customer_info { get; set; }
        public virtual Product Product { get; set; }
    }
}


