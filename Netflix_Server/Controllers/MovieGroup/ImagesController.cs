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
public class ImagesController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public ImagesController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ImageDto>>> GetImages()
    {
        var images = await _context.Images.ToListAsync();
        var imageDtos = _mapper.Map<IEnumerable<ImageDto>>(images);
        return Ok(imageDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ImageDto>> GetImageById(int id)
    {
        var image = await _context.Images.FindAsync(id);
        if (image == null)
        {
            return NotFound();
        }

        var imageDto = _mapper.Map<ImageDto>(image);
        return Ok(imageDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddImage([FromBody] ImageDto imageDto)
    {
        if (imageDto == null)
        {
            return BadRequest();
        }

        var image = _mapper.Map<Image>(imageDto);
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<ImageDto>(image));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateImage(int id, [FromBody] ImageDto imageDto)
    {
        if (imageDto == null)
        {
            return BadRequest();
        }

        var image = await _context.Images.FindAsync(id);
        if (image == null)
        {
            return NotFound();
        }

        _mapper.Map(imageDto, image);
        _context.Images.Update(image);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        var image = await _context.Images.FindAsync(id);
        if (image == null)
        {
            return NotFound();
        }

        _context.Images.Remove(image);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
