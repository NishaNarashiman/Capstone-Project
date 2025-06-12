using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerFeedbackPortal.Models;

namespace CustomerFeedbackPortal.Data
{
    public class CustomerFeedbackPortalContext : DbContext
    {
        public CustomerFeedbackPortalContext (DbContextOptions<CustomerFeedbackPortalContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerFeedbackPortal.Models.Feedback> Feedback { get; set; } = default!;
    }
}
