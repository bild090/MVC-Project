﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApp.Models;
using StudentApp.Core.Models;

namespace StudentApp.Models
{
    public class StudentContext :DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Level> levels { get; set; }
     
        //protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SchoolInfo;Trusted_Connection=True;");
        //}
     
       
        }
}
