using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Insurance.Domain.Entities.File
{
    public interface IEntity
    {
        public object Id { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        public new T Id { get; set; }
    }

    public class BaseEntity<T> : IEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntity.Id
        {
            get => Id;
            set => Id = (T)value;
        }
    }

    public class BaseEntity : BaseEntity<long> { }
}
