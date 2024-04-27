using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodBank.Models;

namespace BloodBank.Data
{
    public class BloodBankContext : DbContext
    {
        public BloodBankContext (DbContextOptions<BloodBankContext> options)
            : base(options)
        {
        }

        public DbSet<BloodBank.Models.Donor> Donor { get; set; } = default!;
        public DbSet<BloodBank.Models.Recipient> Recipient { get; set; } = default!;
        public DbSet<BloodBank.Models.BloodBag> BloodBag { get; set; } = default!;
    }
}
