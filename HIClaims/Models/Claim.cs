using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIClaims.Models
{
    public class Claim
    {
        [Required(ErrorMessage ="Enter a valid Claim Number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Claim Number")]
        public int ClaimNo { get; set; }
        [Required(ErrorMessage = "Enter a valid Customer Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name Should only contain alphabets")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Enter a valid Claim Date")]
        public DateTime ClaimedDate { get; set; }
        [Required(ErrorMessage = "Enter a valid Claim Amount")]
        public float ClaimAmount { get; set; }
        [Required(ErrorMessage = "Enter a valid Policy Number")]
        public int PolicyNo { get; set;}
        public string Gender { get; set; }
        public string Description { get; set; }

    }
}