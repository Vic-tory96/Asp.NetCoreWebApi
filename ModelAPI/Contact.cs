using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAPI
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string FullName { get;set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get;set; }

        [EmailAddress]
        public string Email { get;set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }    

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
