namespace BusinessLogicLayer.Objects.Dtos.Base
{
    public abstract class EntityDto <TId>
    {
        public TId Id { get; set; }

    }
}
