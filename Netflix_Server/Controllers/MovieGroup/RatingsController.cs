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
public class RatingsController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public RatingsController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RatingDto>>> GetRatings()
    {
        var ratings = await _context.Ratings.ToListAsync();
        var ratingDtos = _mapper.Map<IEnumerable<RatingDto>>(ratings);
        return Ok(ratingDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RatingDto>> GetRatingById(int id)
    {
        var rating = await _context.Ratings.FindAsync(id);
        if (rating == null)
        {
            return NotFound();
        }

        var ratingDto = _mapper.Map<RatingDto>(rating);
        return Ok(ratingDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddRating([FromBody] RatingDto ratingDto)
    {
        if (ratingDto == null)
        {
            return BadRequest();
        }

        var rating = _mapper.Map<Rating>(ratingDto);
        await _context.Ratings.AddAsync(rating);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<RatingDto>(rating));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRating(int id, [FromBody] RatingDto ratingDto)
    {
        if (id != ratingDto.Id || ratingDto == null)
        {
            return BadRequest();
        }

        var rating = await _context.Ratings.FindAsync(id);
        if (rating == null)
        {
            return NotFound();
        }

        _mapper.Map(ratingDto, rating);
        _context.Ratings.Update(rating);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRating(int id)
    {
        var rating = await _context.Ratings.FindAsync(id);
        if (rating == null)
        {
            return NotFound();
        }

        _context.Ratings.Remove(rating);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
