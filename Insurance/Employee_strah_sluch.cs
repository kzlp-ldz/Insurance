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
    
    public partial class Employee_strah_sluch
    {
        public int id_fiz_lica { get; set; }
        public int id_contract { get; set; }
        public Nullable<int> id_type { get; set; }
    
        public virtual Contract_pred Contract_pred { get; set; }
        public virtual Fiz_lico Fiz_lico { get; set; }
        public virtual Type_Povred Type_Povred { get; set; }
    }
}
