using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos.Comments
{
    public class DeleteCommentDto : EntityDto<int>
    {
        public string UserId { get; set; }

        public int AdvertId { get; set; }
    }
}
