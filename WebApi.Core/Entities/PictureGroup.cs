using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Entities
{
    public class PictureGroup : Base
    {
        public string PictureImage { get; set; }

        public List<Maintenance> Maintenances { get; set; }
    }
}
