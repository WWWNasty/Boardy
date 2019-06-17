using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos
{
   public class ImageDto : EntityDto<int>
   {
       public string Base64 { get; set; } = string.Empty;
   }
}
