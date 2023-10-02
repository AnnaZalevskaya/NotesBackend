using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Interfaces;

namespace NotesApplication.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler 
        : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly INoteDBContext _dBContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(INoteDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await _dBContext.Notes
                .Where(note => note.UserId == request.UserId)
                .ProjectTo<NoteLookupDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoteListVm { Notes = notesQuery };
        }
    }
}
