//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insurance
{
    using System;
    using System.Collections.Generic;
    
    public partial class Child
    {
        public int id { get; set; }
        public string fio { get; set; }
        public Nullable<int> idSection { get; set; }
        public Nullable<int> age { get; set; }
        public Nullable<int> schoolNumber { get; set; }
        public Nullable<int> grade { get; set; }
        public Nullable<int> idCertificate { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public Nullable<int> idParents { get; set; }
    
        public virtual Certificate Certificate { get; set; }
        public virtual Parents Parents { get; set; }
        public virtual Section Section { get; set; }
    }
}