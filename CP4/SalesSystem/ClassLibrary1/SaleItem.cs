//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaleItem
    {
        public int Id { get; set; }
        public string SaleDate { get; set; }
        public double SaleSum { get; set; }
    
        public virtual Customer Client { get; set; }
        public virtual Product Good { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual InputFile InputFile { get; set; }
    }
}
