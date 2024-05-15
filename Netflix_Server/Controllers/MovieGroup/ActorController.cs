using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Models.MovieGroupDto;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ActorsController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public ActorsController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActorDto>>> GetActors()
    {
        var actors = await _context.Actors
            .Include(a => a.ActorImages)
                .ThenInclude(ai => ai.Image)
            .ToListAsync();

        var actorDtos = _mapper.Map<IEnumerable<ActorDto>>(actors);
        return Ok(actorDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActorDto>> GetActorById(int id)
    {
        var actor = await _context.Actors
            .Include(a => a.ActorImages)
                .ThenInclude(ai => ai.Image)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (actor == null)
        {
            return NotFound();
        }

        var actorDto = _mapper.Map<ActorDto>(actor);
        return Ok(actorDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddActor([FromBody] ActorDto actorDto)
    {
        if (actorDto == null)
        {
            return BadRequest();
        }

        var actor = _mapper.Map<Actor>(actorDto);
        await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<ActorDto>(actor));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActor(int id, [FromBody] ActorDto actorDto)
    {
        if (id != actorDto.Id || actorDto == null)
        {
            return BadRequest();
        }

        var actor = await _context.Actors.FindAsync(id);
        if (actor == null)
        {
            return NotFound();
        }

        _mapper.Map(actorDto, actor);
        _context.Actors.Update(actor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActor(int id)
    {
        var actor = await _context.Actors.FindAsync(id);
        if (actor == null)
        {
            return NotFound();
        }

        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
