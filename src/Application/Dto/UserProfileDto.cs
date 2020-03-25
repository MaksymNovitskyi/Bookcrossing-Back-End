﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Dto
{
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<RoomLocationDto> UserLocation { get; set; }
        
        public virtual List<BookDto> Books { get; set; } 

    }
}