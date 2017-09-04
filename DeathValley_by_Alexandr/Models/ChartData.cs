namespace DeathValley_by_Alexandr.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChartData")]
    public partial class ChartData:Entities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChartData()
        {
            Сoordinates = new HashSet<Сoordinates>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string InputData { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Сoordinates> Сoordinates { get; set; }
    }
}
