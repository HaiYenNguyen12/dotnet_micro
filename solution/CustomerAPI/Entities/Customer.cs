using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Entities
{
    
        [Table("customer")]
        public class Customer
        {
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }
            public string MobiNumber { get; set; }
            public string Email { get; set; }

        }
    
}
