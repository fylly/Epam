//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.SaleItem = new HashSet<SaleItem>();
        }
    
        public int Id { get; set; }
        public string CustomerName { get; set; }
    
        public virtual ICollection<SaleItem> SaleItem { get; set; }
    }
}
