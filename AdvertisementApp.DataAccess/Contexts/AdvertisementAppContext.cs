﻿using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Contexts
{
    //Entitiylerimizin database contextlerini ayarlıyoruz
    public class AdvertisementAppContext :DbContext
    {
        public AdvertisementAppContext(DbContextOptions<AdvertisementAppContext> options):base(options)
        {
        }

        public DbSet<Advertisement>Advertisements { get; set; }
        public DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
        public DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses{ get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<ProvidedService> ProvidedServices{ get; set; }

    }
}
