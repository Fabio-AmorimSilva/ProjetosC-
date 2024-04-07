﻿namespace Library.Application.Commands.Library.CreateLibrary;

public readonly struct CreateLibraryCommand(string name, string city) : IRequest<ResultResponse<Unit>>
{
    public string Name { get; init; } = name;
    public string City { get; init; } = city;
}