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
public class CompaniesController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public CompaniesController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
    {
        var companies = await _context.Companies
            .Include(d => d.CompanyImages)
                .ThenInclude(d => d.Image)
            .ToListAsync();

        var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return Ok(companyDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDto>> GetCompanyById(int id)
    {
        var company = await _context.Companies
            .Include(d => d.CompanyImages)
                .ThenInclude(d => d.Image)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (company == null)
        {
            return NotFound();
        }

        var companyDto = _mapper.Map<CompanyDto>(company);
        return Ok(companyDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddCompany([FromBody] CompanyDto companyDto)
    {
        if (companyDto == null)
        {
            return BadRequest();
        }
        var company = _mapper.Map<Company>(companyDto);

        company.Id = default;
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();

        return Ok(_mapper.Map<CompanyDto>(company));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyDto companyDto)
    {
        if (id != companyDto.Id || companyDto == null)
        {
            return BadRequest();
        }

        var company = await _context.Companies.FindAsync(id);
        if (company == null)
        {
            return NotFound();
        }

        _mapper.Map(companyDto, company);
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company == null)
        {
            return NotFound();
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
