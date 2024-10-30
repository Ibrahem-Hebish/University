﻿using UniversityProject.Core.CQSR.Queries.CourseQueries;

namespace Universityproject.Api.Controllers;


public class CourseController(IMediator mediator) : AppController
{
    [HttpGet]
    [Route(Router.Course.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetCourseDto>> Get(int id)
    {
        var Section = await mediator.Send(new GetCourseById(id));

        return NewRsponse(Section);
    }

    [HttpGet]
    [Route(Router.Course.GetAll)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetCourseDto>>> GetAll()
    {
        var Sections = await mediator.Send(new GetAllCourses());

        return NewRsponse(Sections);
    }

    [HttpGet]
    [Route(Router.Course.GetAllInSpecificTerm)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GetCourseDto>>> GetAllInSpecificTerm(int Level, int Term)
    {
        var Sections = await mediator.Send(new GetAllCoursesInASpecificTerm(Level, Term));

        return NewRsponse(Sections);
    }

    [HttpGet]
    [Route(Router.Course.GetCourseDoctor)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetDoctorDto>> GetSectionTeachingAssistant(int id)
    {
        var TeachingAssistant = await mediator.Send(new GetCourseDoctor(id));

        return NewRsponse(TeachingAssistant);
    }

}