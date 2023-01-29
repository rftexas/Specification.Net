using Microsoft.EntityFrameworkCore;

namespace Specification.Net.EntityFrameworkCore;

public static class EntityFrameworkCoreExtension {
    public static bool All<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.All(spec.Expression);
    public static Task<bool> AllAsync<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.AllAsync(spec.Expression);
    
    public static bool Any<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.Any(spec.Expression);
    public static Task<bool> AnyAsync<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.AnyAsync(spec.Expression);

    public static TEntity First<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.First(spec.Expression);
    public static Task<TEntity> FirstAsync<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.FirstAsync(spec.Expression);

    public static TEntity FirstOrDefault<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.FirstOrDefault(spec.Expression);
    public static Task<TEntity> FirstOrDefaultAsync<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.FirstOrDefaultAsync(spec.Expression);

    public static TEntity Single<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.SingleOrDefault(spec.Expression);
    public static Task<TEntity> SingleOrDefaultAsync<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.SingleOrDefaultAsync(spec.Expression);

    public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> spec) =>
        queryable.Where(spec.Expression);
    
}