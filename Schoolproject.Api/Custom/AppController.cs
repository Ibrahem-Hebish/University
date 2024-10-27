﻿namespace Universityproject.Api.Custom;

[ApiController]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[EnableRateLimiting(policyName: "slidingPolicy")]

public class AppController()
            : ControllerBase
{

    public ObjectResult NewRsponse<T>(
        Response<T> response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK: return new OkObjectResult(response);

            case HttpStatusCode.Created: return new CreatedResult("", response);

            case HttpStatusCode.NotFound: return new NotFoundObjectResult(response);

            case HttpStatusCode.BadRequest: return new BadRequestObjectResult(response);

            case HttpStatusCode.Unauthorized: return new UnauthorizedObjectResult(response);

            case HttpStatusCode.UnprocessableEntity: return new UnprocessableEntityObjectResult(response);

            case HttpStatusCode.NoContent: return new OkObjectResult(response);
        }

        return new ObjectResult(response);
    }
}
