﻿namespace Library.Application.Commands.Library.CreateLibrary;

public struct CreateLibraryCommand(string name, string city) : IRequest<ResultViewModel<Unit>>
{
    public string Name { get; init; } = name;
    public string City { get; init; } = city;
}