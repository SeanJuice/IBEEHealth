//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deliverable04.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DietRecipe
    {
        public int RecipeID { get; set; }
        public int DietID { get; set; }
        public int ID { get; set; }
    
        public virtual Diet Diet { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
