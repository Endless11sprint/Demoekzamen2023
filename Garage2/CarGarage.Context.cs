﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Garage2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarGarageEntities : DbContext
    {
        private static CarGarageEntities _context;
        public CarGarageEntities()
            : base("name=CarGarageEntities")
        {
        }
        public static CarGarageEntities GetContext()
        {
            if (_context == null)
            {
                _context = new CarGarageEntities();
            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarOwner> CarOwner { get; set; }
        public virtual DbSet<Garage> Garage { get; set; }
        public virtual DbSet<OwnersAndTheirCars> OwnersAndTheirCars { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Watchman> Watchman { get; set; }
    }
}