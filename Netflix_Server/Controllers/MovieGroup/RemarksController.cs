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
public class RemarksController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public RemarksController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RemarkDto>>> GetRemarks()
    {
        var remarks = await _context.Remarks.ToListAsync();
        var remarkDtos = _mapper.Map<IEnumerable<RemarkDto>>(remarks);
        return Ok(remarkDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RemarkDto>> GetRemarkById(int id)
    {
        var remark = await _context.Remarks.FindAsync(id);
        if (remark == null)
        {
            return NotFound();
        }

        var remarkDto = _mapper.Map<RemarkDto>(remark);
        return Ok(remarkDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddRemark([FromBody] RemarkDto remarkDto)
    {
        if (remarkDto == null)
        {
            return BadRequest();
        }

        var remark = _mapper.Map<Remark>(remarkDto);
        await _context.Remarks.AddAsync(remark);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<RemarkDto>(remark));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRemark(int id, [FromBody] RemarkDto remarkDto)
    {
        if (id != remarkDto.Id || remarkDto == null)
        {
            return BadRequest();
        }

        var remark = await _context.Remarks.FindAsync(id);
        if (remark == null)
        {
            return NotFound();
        }

        _mapper.Map(remarkDto, remark);
        _context.Remarks.Update(remark);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRemark(int id)
    {
        var remark = await _context.Remarks.FindAsync(id);
        if (remark == null)
        {
            return NotFound();
        }

        _context.Remarks.Remove(remark);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
