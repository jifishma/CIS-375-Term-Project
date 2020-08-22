namespace Hotel_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            PriceHistories = new HashSet<PriceHistory>();
            Reservations = new HashSet<Reservation>();
            ViewHistories = new HashSet<ViewHistory>();
        }

        public enum Availabilities
        {
            available = 1,
            booked,
            maintenance
        }

        public enum Types
        {
            small = 1,
            medium,
            large
        }

        public int roomID { get; set; }

        public int hotelID { get; set; }

        public int availability { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int type { get; set; }

        [Required]
        [StringLength(50)]
        public string location { get; set; }

        public int capacity { get; set; }

        public double price { get; set; }

        public int rewards { get; set; }

        public int timesViewed { get; set; }

        public virtual Hotel Hotel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceHistory> PriceHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViewHistory> ViewHistories { get; set; }
    }
}
