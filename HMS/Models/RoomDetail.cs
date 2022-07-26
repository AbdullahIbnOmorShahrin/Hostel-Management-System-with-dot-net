//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RoomDetail
    {
        
        public int Id { get; set; }
        [Required]
        [Range(1000, 9000, ErrorMessage = "Room Id should be withween One Thousand to Nine Thousand")]
        public int RoomNo { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Member should be withween One to Five")]
        public int Capacity { get; set; }
        public int AssignedMember { get; set; }
        public int SeatAvailable { get; set; }
        [Required]
        public string RoomSpec { get; set; }
    }
}
