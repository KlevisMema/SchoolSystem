namespace SchoolSystem.BLL.ServiceInterfaces
{
    /// <summary>
    ///     Interface that validates an id
    /// </summary>
    /// <typeparam name="T"> Type of the entity </typeparam>
    public interface I_Valid_Id<T>
    {
        /// <summary>
        ///     Validate Id 
        /// </summary>
        /// <param name="id"> Id of a record in database of an enitity </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> True if exists and false if not </returns>
       Task<bool> Bool(Guid id, CancellationToken cancellationToken);
    }
}