using Microsoft.AspNetCore.Mvc;

using DevelopersApi.Models;
using System.Runtime.InteropServices;

namespace DevelopersApi.Controllers;

public class DevelopersController : ControllerBase
{

    // GET /on-call-developer
    [HttpGet("/on-call-developer")]
    public ActionResult GetOnCallDeveloper ()
    {

        var response = new DeveloperDetailsModel("1", "Jeff", "Gonzalez", "555-1212", "jeff@hypertheory.com");

        return Ok(response); // 200 Status code.
    }

public record DeveloperSummaryModel(string Id, string FirstName, string LastName, string Email);

    public class CollectionResponse<T>
    {
        public List<T> Data { get; set; } = new();
    }
    [HttpGet("/developers")] public ActionResult GetAllDevelopers() { var response = new CollectionResponse<DeveloperSummaryModel>(); response.Data = new List<DeveloperSummaryModel>() { new DeveloperSummaryModel("1", "Jeff", "Gonzalez", "jeff@hypertheory.com"), new DeveloperSummaryModel("2", "Sue", "Jones", "sue@aol.com") }; return Ok(response); }

    [HttpPost("/developers")]
    public ActionResult AddADeveloper([FromBody] DeveloperCreateModel request)
    {
        var response = new DeveloperDetailsModel(Guid.NewGuid().ToString(), request.FirstName, request.LastName, request.Email, request.Phone);
        return StatusCode(201, response); // "Good. Ok. I created this.
    }
}
