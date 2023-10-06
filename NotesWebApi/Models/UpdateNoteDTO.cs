using AutoMapper;
using NotesApplication.Common.Mappings;
using NotesApplication.Notes.Commands.UpdateNote;

namespace NotesWebApi.Models
{
    public class UpdateNoteDTO : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDTO, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                opt => opt.MapFrom(noteDTO => noteDTO.Id))
                .ForMember(noteCommand => noteCommand.Title,
                opt => opt.MapFrom(noteDTO => noteDTO.Title))
                .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDTO => noteDTO.Details));
        }
    }
}
