namespace TSA.Core.Application.Repositories.Common;

public interface IQuery<T>
{
    IQueryable<T> Query();
}