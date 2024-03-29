﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Implementation.Services.Base
{
    public abstract class BaseService
    {
        protected void Validate(object entity)
        {
            var validationContext = new ValidationContext(entity);
            Validator.ValidateObject(entity, validationContext);
        }
    }
}
