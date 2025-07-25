﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models
{
    [Comment("Manager in the system")]
    public class Manager
    {
        [Comment("Manager's identifier")]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        [Comment("Manager's user entity")]
        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;

        public virtual ICollection<Cinema> ManagedCinema { get; set; }
        = new HashSet<Cinema>();
    }
}
