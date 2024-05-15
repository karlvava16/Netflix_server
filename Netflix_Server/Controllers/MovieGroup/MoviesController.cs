using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Models.MovieGroupDto;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public MoviesController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie([FromBody] MovieDto movieDto)
    {
        if (movieDto == null)
        {
            return BadRequest();
        }

        var movie = _mapper.Map<Movie>(movieDto);
        movie.Id = default;

        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<MovieDto>(movie));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
    {
        var movies = await _context.Movies
            .Include(m => m.MovieImages)
                .ThenInclude(a => a.Image)
            .Include(m => m.Remark)
            .Include(m => m.Rating)
            .Include(m => m.Genres)
            .Include(m => m.Actors)
                .ThenInclude(a => a.ActorImages)
                    .ThenInclude(a => a.Image)
            .Include(m => m.Director)
                .ThenInclude(a => a.DirectorImages)
                    .ThenInclude(a => a.Image)
            .Include(m => m.Company)
                .ThenInclude(a => a.CompanyImages)
                    .ThenInclude(a => a.Image)
            .ToListAsync();

        var movieDtos = _mapper.Map<IEnumerable<MovieDto>>(movies);
        return Ok(movieDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetMovieById(int id)
    {
        var movie = await _context.Movies
            .Include(m => m.MovieImages)
                .ThenInclude(a => a.Image)
            .Include(m => m.Remark)
            .Include(m => m.Rating)
            .Include(m => m.Genres)
            .Include(m => m.Actors)
            .Include(m => m.Actors)
                .ThenInclude(a => a.ActorImages)
                    .ThenInclude(a => a.Image)
            .Include(m => m.Director)
                .ThenInclude(a => a.DirectorImages)
                    .ThenInclude(a => a.Image)
            .Include(m => m.Company)
                .ThenInclude(a => a.CompanyImages)
                    .ThenInclude(a => a.Image)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            return NotFound();
        }

        var movieDto = _mapper.Map<MovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDto movieDto)
    {
        if (id != movieDto.Id || movieDto == null)
        {
            return BadRequest();
        }

        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

        _mapper.Map(movieDto, movie);

        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
