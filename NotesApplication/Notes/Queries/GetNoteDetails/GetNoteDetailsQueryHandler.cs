using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.CommonMappings.Exceptions;
using NotesApplication.Interfaces;
using NotesDomain;

namespace NotesApplication.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler 
        : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INoteDBContext _dBContext;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(INoteDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dBContext.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                new NotFoundException(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
