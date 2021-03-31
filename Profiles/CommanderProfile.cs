using AutoMapper;
using WebAPISample.Dtos;
using WebAPISample.Models;

namespace WebAPISample.Profiles
{
    public class CommanderProfile :Profile
    {
        public CommanderProfile()
        {
            // Source -> Destination
            CreateMap<Command, CommanderReadDto>();
            CreateMap<CommanderCreateDto, Command>();
            CreateMap<CommanderUpdateDto,Command>();
            CreateMap<Command,CommanderUpdateDto>();
        }
    }
}