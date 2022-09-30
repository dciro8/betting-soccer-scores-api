namespace betting.soccer.scores.api.Domains
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
