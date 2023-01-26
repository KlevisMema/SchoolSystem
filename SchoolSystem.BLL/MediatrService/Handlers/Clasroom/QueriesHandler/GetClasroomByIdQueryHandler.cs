#region Usings

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.DTO.ViewModels.Clasroom;
using SchoolSystem.BLL.RepositoryServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries;

#endregion

namespace SchoolSystem.BLL.MediatrService.Handlers.Clasroom.QueriesHandler
{
    /// <summary>
    ///     Get clasroom query handler class which implements IRequestHandler which gets the get clasroom query and object result as response 
    /// </summary>
    public class GetClasroomByIdQueryHandler : IRequestHandler<GetClasroomsByIdQuery, ObjectResult>
    {

        /// <summary>
        ///     ICrudService interface 
        /// </summary>
        private readonly ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> _clasroomService;
        /// <summary>
        ///     IControllerStatusCodeResponse interface
        /// </summary>
        private readonly IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> _statusCodeResponse;

        /// <summary>
        ///     Services injection
        /// </summary>
        /// <param name="clasroomService"> Clasroom service  </param>
        /// <param name="statusCodeResponse"> Status code service </param>
        public GetClasroomByIdQueryHandler
        (
           ICrudService<ClasroomViewModel, CreateUpdateClasroomViewModel> clasroomService,
           IControllerStatusCodeResponse<ClasroomViewModel, List<ClasroomViewModel>> statusCodeResponse
        )
        {
            _clasroomService = clasroomService;
            _statusCodeResponse = statusCodeResponse;
        }

        /// <summary>
        ///     Handle the get clasroom by id query
        /// </summary>
        /// <param name="request"> Request parameters </param>
        /// <param name="cancellationToken"> Cancellation token </param>
        /// <returns> A Object result response </returns>
        public async Task<ObjectResult> Handle
        (
            GetClasroomsByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var clasroom = await _clasroomService.GetRecord(request.Id, cancellationToken);
            return _statusCodeResponse.ControllerResponse(clasroom);
        }
    }
}