using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Notes.Commands.CreateNote;
using NotesApplication.Notes.Commands.DeleteNote;
using NotesApplication.Notes.Commands.UpdateNote;
using NotesApplication.Notes.Queries.GetNoteDetails;
using NotesApplication.Notes.Queries.GetNoteList;
using NotesWebApi.Models;

namespace NotesWebApi.Controllers
{
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;

        public NoteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDTO createNoteDTO)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDTO);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);

            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDTO updateNoteDTO)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDTO);
            command.UserId = UserId;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);

            return NoContent();
        }

    }
}
