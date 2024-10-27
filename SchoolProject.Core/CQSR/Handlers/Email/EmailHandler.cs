namespace UniversityProject.Core.CQSR.Handlers.Email;

public class EmailHandler(
    IEmailService emailService)
    : ResponseHandler,
    IRequestHandler<SendEmailCommand, Response<String>>
{

    public async Task<Response<string>> Handle(
        SendEmailCommand request,
        CancellationToken cancellationToken)

    {
        var result = await emailService
            .SendEmailAsync(request.Email,
                            request.message,
                            request.subject);

        if (result == "Success") return NoContent<string>("Sending email complated");

        return BadRequest<string>("Sending email failed");
    }
}
