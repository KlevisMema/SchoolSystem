using MediatR;
using SchoolSystem.BLL.ResponseService;
using SchoolSystem.BLL.ServiceInterfaces;
using SchoolSystem.BLL.MediatrService.Actions.Clasroom.Queries;

namespace SchoolSystem.BLL.MediatrService.Handlers.Clasroom.QueriesHandler
{
    public class DoesClasroomExistsQueryHandler : IRequestHandler<DoesClasroomExistsQuery, CustomMesageResponse>
    {
        private readonly I_Valid_Id<SchoolSystem.DAL.Models.Clasroom> _Clasroom_Valid_Id;

        public DoesClasroomExistsQueryHandler
        (
            I_Valid_Id<DAL.Models.Clasroom> Clasroom_Valid_Id
        )
        {
            _Clasroom_Valid_Id = Clasroom_Valid_Id;
        }
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