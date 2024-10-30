﻿namespace UniversityProject.Core.CQSR.Commands.Teaching_Assistants_Commands;

public record ChangeTeachingAssistantOffice(int Id, string OfficeName, int DepId)
    : IRequest<Response<GetTeachingAssistantDto>>
{ }
public record DeleteTeachingAssistant(int Id) : IRequest<Response<string>> { }