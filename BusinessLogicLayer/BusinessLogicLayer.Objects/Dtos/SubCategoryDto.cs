using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Objects.Dtos
{
    public class SubCategoryDto
    {
        

        [Required]
        [Display(Name = "Subcategory Id")]
        public int Id { get; set; }

        [Display(Name = "Subcategory")]
        public string Name { get; set; }

        public SubCategoryDto Parent { get; set; }

        protected bool Equals(SubCategoryDto other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SubCategoryDto)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
