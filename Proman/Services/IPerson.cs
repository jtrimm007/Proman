namespace Proman.Services
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IPerson" />
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// The Read
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Person"/></returns>
        Person Read(int id);

        /// <summary>
        /// The ReadAll
        /// </summary>
        /// <returns>The <see cref="ICollection{Person}"/></returns>
        ICollection<Person> ReadAll();

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        void Delete(int id);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="person">The person<see cref="Person"/></param>
        void Update(Person person);

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="person">The person<see cref="Person"/></param>
        void Add(Person person);

        /// <summary>
        /// The SelectAllPeopleById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="List{string}"/></returns>
        List<string> SelectAllPeopleById(int id);
    }
}
