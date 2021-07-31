namespace de_institutions_api_core.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}