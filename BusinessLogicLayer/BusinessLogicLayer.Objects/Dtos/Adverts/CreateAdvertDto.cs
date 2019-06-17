using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Objects.Dtos.Adverts
{
    public class CreateAdvertDto
    {
        public const int MaxImagesCount = 5;

        [MaxLength(100)]
        [Required(ErrorMessage = "Поле \"Название\" является обязательным!")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Поле \"Описание\" является обязательным!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле \"Телефон\" является обязательным!")]
        [Phone]
        [MaxLength(20)]
        [MinLength(10)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле \"Цена\" является обязательным!")]
        public uint Price { get; set; }

        [Required]
        public AddressDto Address { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Поле \"Подкатегория\" является обязательным!")]
        public int? SubCategoryId { get; set; }
        
        [MaxLength(MaxImagesCount)]
        public ImageDto[] AdvertImages { get; set; } = new ImageDto[MaxImagesCount];
    }
}
