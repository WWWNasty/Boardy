namespace DataAccessLayer.Models.Entities.Base
{
    public abstract class Entity<TId>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public TId Id { get; set; }

      }
}