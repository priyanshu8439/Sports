//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sports
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public string CatId { get; set; }
        public string CatName { get; set; }
        public string ProId { get; set; }
        public string catDescription { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
