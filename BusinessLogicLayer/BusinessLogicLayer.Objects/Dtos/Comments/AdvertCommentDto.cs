using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos.Comments
{
    /// <summary>
    /// Комментарий к объявлению
    /// </summary>
    public class AdvertCommentDto: EntityDto<int>
    {
        [Required]
        public string Text { get; set; }
        
        public string UserId { get; set; }

        public string UserName { get; set; }

        public int AdvertId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}