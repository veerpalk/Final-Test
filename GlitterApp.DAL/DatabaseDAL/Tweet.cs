//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlitterApp.DAL.DatabaseDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tweet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tweet()
        {
            this.TweetLikeDislikes = new HashSet<TweetLikeDislike>();
        }
    
        public int Tid { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreationTime { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TweetLikeDislike> TweetLikeDislikes { get; set; }
    }
}