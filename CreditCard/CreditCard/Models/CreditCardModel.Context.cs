﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CreditCard.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CreditCardEntities : DbContext
    {
        public CreditCardEntities()
            : base("name=CreditCardEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<creditcard> creditcards { get; set; }
    
        public virtual int CheckCreditCardIfExists(string cardnumber)
        {
            var cardnumberParameter = cardnumber != null ?
                new ObjectParameter("cardnumber", cardnumber) :
                new ObjectParameter("cardnumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckCreditCardIfExists", cardnumberParameter);
        }
    }
}