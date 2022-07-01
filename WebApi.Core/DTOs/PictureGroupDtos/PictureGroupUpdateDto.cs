using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs.PictureGroupDtos
{
    public class PictureGroupUpdateDto
    {
        public int ID { get; set; }
        public string PictureImage { get; set; }
        public int ModifiedBy { get; set; }
    }
}
