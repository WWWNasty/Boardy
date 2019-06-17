using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos.Comments
{
    public class CreateCommentDto
    {
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int AdvertId { get; set; }

    }
}
