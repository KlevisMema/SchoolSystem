#region Usings

using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Clasroom.QueriesHandler
{
    /// <summary>
    ///     Does clasroom exists query handler class which implements IRequestHandler which gets the Does Clasroom Exists Query and CustomMesageResponse as response.
    /// </summary>
    public class DoesClasroomExistsQueryHandler : IRequestHandler<DoesClasroomExistsQuery, CustomMesageResponse>
    {
        /// <summary>
        ///     I_Valid_Id interface 
        /// </summary>
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Clasroom> _Clasroom_Valid_Id;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="clasroom_Valid_Id"> Valid id service  </param>
        public DoesClasroomExistsQueryHandler
        (
            I_Valid_Id<DAL.Models.Clasroom> clasroom_Valid_Id
        )
        {
            _Clasroom_Valid_Id = clasroom_Valid_Id;
        }

        /// <summary>
        ///     Handle the does clasroom exists command
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<CustomMesageResponse> Handle
        (
            DoesClasroomExistsQuery request,
            CancellationToken cancellationToken
        )
        {
            var clasroom = await _Clasroom_Valid_Id.Bool(request.Id, cancellationToken);

            if (clasroom)
                return CustomMesageResponse.Succsess();

            return CustomMesageResponse.NotFound(clasroom, "Invalid clasroom id");
        }
    }
}
