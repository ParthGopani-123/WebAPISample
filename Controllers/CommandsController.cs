using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Data;
using WebAPISample.Dtos;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    // api/commands -- It depends on the controller name
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper = mapper;
        }


        // This is the action of commandsController to get all the commands out from our model 
        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommanderReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<Command>>(commandItems));
        }

        
        // GET api/commands/{id}  OR  5 
        [HttpGet("{id}", Name="GetCommandByID")]
        public ActionResult <CommanderReadDto> GetCommandByID(int id)
        {
            var commandItem = _repository.GetCommandByID(id);

            if(commandItem!=null)
            {
            return Ok(_mapper.Map<CommanderReadDto>(commandItem));
            }
            return NotFound();
        }

        // Post api/commands
        [HttpPost]
        public ActionResult <CommanderReadDto> CreateCommand(CommanderCreateDto commanderCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commanderCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChages();

            var commanderReadDto = _mapper.Map<CommanderReadDto>(commandModel);

            //return Ok(_mapper.Map<CommanderReadDto>(commandModel));
            //return RedirectToAction("GetCommandByID","Commands", new {id = commandModel.Id});
            return CreatedAtRoute(nameof(GetCommandByID), new {Id = commandModel.Id}, commanderReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommanderUpdateDto commanderUpdateDto)
        {
            var updateCommandModel = _repository.GetCommandByID(id);
            
            if(updateCommandModel == null)
            {
                return NotFound();
            }

            _mapper.Map(commanderUpdateDto,updateCommandModel);
            _repository.SaveChages();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommanderUpdateDto> patchDoc)
        {
            var updateCommandModel = _repository.GetCommandByID(id);
            
            if(updateCommandModel == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommanderUpdateDto>(updateCommandModel);

            patchDoc.ApplyTo(commandToPatch, ModelState);
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch,updateCommandModel);
            _repository.SaveChages();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var getCommandForDete = _repository.GetCommandByID(id);

            if(getCommandForDete == null)
            {
                return NotFound();
            }

            _repository.DeteleCommand(getCommandForDete);
            _repository.SaveChages();

            return NoContent();
        }


    }
}