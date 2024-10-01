using Application.Services.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CandidateController : ControllerBase
{
    private readonly ICandidateService _candidateService;
    public CandidateController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _candidateService.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Candidate candidate)
    {
        var result = await _candidateService.Create(candidate);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Guid id)
    {
        try
        {
            var result = await _candidateService.Delete(id);
            return Ok("Candidato Removido com sucesso!");
        }
        catch (Exception)
        {

            throw;
        }
    }

}
