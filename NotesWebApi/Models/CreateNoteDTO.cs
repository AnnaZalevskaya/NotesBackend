using AutoMapper;
using NotesApplication.Common.Mappings;
using NotesApplication.Notes.Commands.CreateNote;

namespace NotesWebApi.Models
{
    public class CreateNoteDTO : IMapWith<CreateNoteCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDTO, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                opt => opt.MapFrom(noteDTO => noteDTO.Title))
                .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDTO => noteDTO.Details));
        }
    }
}
