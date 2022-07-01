using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Core.Entities
{
    public abstract class Base
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

       
        public int CreatedBy { get; set; }
        
        public DateTime ModifyDate { get; set; }

       
        public int ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        
        public User CreatedByUser { get; set; }
        
        public User ModifiedByUser { get; set; }


    }
}
