//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTL_nhom2_demo.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Khachhang()
        {
            this.tb_HDB = new HashSet<tb_HDB>();
        }
    
        public int ma_kh { get; set; }
        public string ten_kh { get; set; }
        public string dia_chi { get; set; }
        public string dien_thoai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_HDB> tb_HDB { get; set; }
    }
}
