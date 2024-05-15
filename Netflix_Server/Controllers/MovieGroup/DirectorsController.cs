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
public class DirectorsController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public DirectorsController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DirectorDto>>> GetDirectors()
    {
        var directors = await _context.Directors
            .Include(d => d.DirectorImages)
                .ThenInclude(d => d.Image)
            .ToListAsync();

        var directorDtos = _mapper.Map<IEnumerable<DirectorDto>>(directors);
        return Ok(directorDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DirectorDto>> GetDirectorById(int id)
    {
        var director = await _context.Directors
            .Include(d => d.DirectorImages)
                .ThenInclude(d => d.Image)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (director == null)
        {
            return NotFound();
        }

        var directorDto = _mapper.Map<DirectorDto>(director);
        return Ok(directorDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddDirector([FromBody] DirectorDto directorDto)
    {
        if (directorDto == null)
        {
            return BadRequest();
        }

        var director = _mapper.Map<Director>(directorDto);
        await _context.Directors.AddAsync(director);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<DirectorDto>(director));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDirector(int id, [FromBody] DirectorDto directorDto)
    {
        if (id != directorDto.Id || directorDto == null)
        {
            return BadRequest();
        }

        var director = await _context.Directors.FindAsync(id);
        if (director == null)
        {
            return NotFound();
        }

        _mapper.Map(directorDto, director);
        _context.Directors.Update(director);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDirector(int id)
    {
        var director = await _context.Directors.FindAsync(id);
        if (director == null)
        {
            return NotFound();
        }

        _context.Directors.Remove(director);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
