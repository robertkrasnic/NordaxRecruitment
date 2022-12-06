using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Nordax.Bank.Recruitment.DataAccess.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        /// <inheritdoc cref="BaseRepository{T}.GetAll"/>
        Task<IEnumerable<T>> GetAll();

        /// <inheritdoc cref="BaseRepository{T}.GetById"/>
        Task<T> GetById(int id);

        /// <inheritdoc cref="BaseRepository{T}.Where"/>
        IEnumerable<T> Where(Expression<Func<T, bool>> exp);


        /// <inheritdoc cref="BaseRepository{T}.WhereAsync"/>        
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp);

        /// <inheritdoc cref="BaseRepository{T}.Insert"/>
        Task Insert(T entity);

        /// <inheritdoc cref="BaseRepository{T}.Update"/>
        Task Update(T entity);

        /// <inheritdoc cref="BaseRepository{T}.Delete"/>
        Task Delete(T entity);
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        internal DbSet<T> _entities;
        
        public BaseRepository(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
            this._entities = this._context.Set<T>();
        }

        /// <summary>
        /// Asynchronously get all entities.
        /// </summary>
        /// <returns>IEnumerable of all entities of type T>></returns>
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        /// <summary>
        /// Asynchronously gets a single the Entity by Id.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <returns>An Entity of type T.</returns>
        public virtual async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
            
        }


        /// <summary>
        /// Synchronously filters the entity table by the predicate.
        /// </summary>
        /// <param name="exp">Query expression.</param>
        /// <returns>An IEnumerable of T that satisfy the condition specified by predicate.</returns>
        public IEnumerable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _entities.Where(exp);
        }

        /// <summary>
        /// Asynchronously filters the entity table by the predicate.
        /// </summary>
        /// <param name="exp">Filter predicate.</param>
        /// <returns>An IEnumerable of T that satisfy the condition specified by predicate.</returns>
        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
            return await _entities.Where(exp).ToListAsync();
        }

        /// <summary>
        /// Asynchronously inserts new entity.
        /// </summary>
        /// <param name="entity">New T entity.</param>
        /// <exception cref="ArgumentNullException">Entity is null.</exception>
        public async Task Insert(T entity)
        {
            //if (entity == null)
            //{
            //    throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));
            //}

            await _entities.AddAsync(entity);
        }

        /// <summary>
        /// Asynchronously update the entity.
        /// </summary>
        /// <param name="entity">T entity to be updated.</param>
        /// <exception cref="ArgumentNullException">Entity is null.</exception>
        public async Task Update(T entity)
        {
            var oldEntity = await _context.FindAsync<T>(entity);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
        }

        /// <summary>
        /// Asynchronously hard deletes the entity.
        /// </summary>
        /// <param name="entity">T Entity to be deleted.</param>
        /// <exception cref="ArgumentNullException">Entity is null.</exception>
        public async Task Delete(T entity)
        {
            _entities.Remove(entity);
        }

    }



}