﻿using IdentityServer4.EntityFramework.Options;
using LogApp.Application.Common.Interfaces;
using LogApp.Domain.Common;
using LogApp.Domain.Entities;
using LogApp.Infrastructure.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Infrastructure.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Carrier> Carriers { get; set; }

        public DbSet<CostCenter> CostCenters { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<ShipmentStatus> ShipmentStatuses { get; set; }

        public DbSet<WarehouseStatus> WarehouseStatuses { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {

                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.DeletedBy = _currentUserService.UserId;
                    entry.Entity.Deleted = DateTime.UtcNow;
                    entry.Entity.IsDeleted = true;

                    entry.State = EntityState.Modified;

                    return base.SaveChangesAsync(cancellationToken);
                }

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
