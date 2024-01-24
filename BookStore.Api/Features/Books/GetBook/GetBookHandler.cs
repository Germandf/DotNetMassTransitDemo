﻿using MediatR;
using FluentResults;
using BookStore.Api.Persistence;

namespace BookStore.Api.Features.Books.GetBook;

public class GetBookHandler(
    IRepository<Book> bookRepository)
    : IRequestHandler<GetBookRequest, Result<Book>>
{
    public async Task<Result<Book>> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id);

        if (book is null)
            return Result.Fail($"Book with id {request.Id} was not found");

        return Result.Ok(book);
    }
}
