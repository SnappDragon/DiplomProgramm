﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Дипломная_работа
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class diplomEntities1 : DbContext
    {

        private static diplomEntities1 _context;

        public diplomEntities1()
            : base("name=diplomEntities1")
        {
        }
    
        public static diplomEntities1 GetContext()
        {
            if (_context == null)
                _context = new diplomEntities1();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<autopark> autopark { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<transport> transport { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<voditel> voditel { get; set; }
        public virtual DbSet<worker> worker { get; set; }
        public virtual DbSet<role> role { get; set; }
    }
}
