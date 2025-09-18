using System.Linq.Expressions;

namespace CharacterProgression;

public abstract class Specification<T>
{
    public bool IsSatisfiedBy(T value) => ToExpression().Compile()(value);

    protected abstract Expression<Func<T, bool>> ToExpression();

    public static implicit operator Expression<Func<T, bool>>(Specification<T> source) => source.ToExpression();
    public static implicit operator Func<T, bool>(Specification<T> source) => source.ToExpression().Compile();
}
