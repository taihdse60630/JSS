//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobSearchingSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();
            this.Messages = new HashSet<Message>();
            this.MessageReceivers = new HashSet<MessageReceiver>();
            this.Reports = new HashSet<Report>();
            this.Reports1 = new HashSet<Report>();
            this.Topics = new HashSet<Topic>();
            this.AspNetRoles = new HashSet<AspNetRole>();
        }
    
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Discriminator { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Administrator Administrator { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Jobseeker Jobseeker { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<MessageReceiver> MessageReceivers { get; set; }
        public virtual Recruiter Recruiter { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Report> Reports1 { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
