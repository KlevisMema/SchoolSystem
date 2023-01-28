#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;

#endregion

namespace SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries
{
    /// <summary>
    ///     Get clasroom query class which inherit from IRequest that holds an CustomMesageResponse as a response.
    /// </summary>
    public class DoesClasroomExistsQuery : IRequest<CustomMesageResponse>
    {
        /// <summary>
        ///     Id of the clasroom 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Instansiate DoesClasroomExistsQuery passing the clasroom id as parameter
        /// </summary>
        /// <param name="id"> Id of the clasroom passed to the constructor </param>
        public DoesClasroomExistsQuery
        (
            Guid id
        )
        {
            Id = id;
        }
    }
}