﻿using EntityFrameworkDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkDataAccessLibrary.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> People {  get; set;}
        public DbSet<Address> Addresses {  get; set;}
        public DbSet<Email> EmailAddresses {  get; set;}
    }
}
