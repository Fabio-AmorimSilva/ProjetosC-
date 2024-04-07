﻿namespace Library.Application.Commands.Library.UpdateLibrary;

public struct UpdateLibraryCommand : IRequest<ResultResponse<Unit>>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string City { get; init; }

    public UpdateLibraryCommand(Guid id, string name, string city)
    {
        Id = id;
        Name = name;
        City = city;
    }
}