﻿using BookStore.Api.Common;
using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.GetBook;

public class GetBookHandler(
    IRepository<Book> bookRepository)
    : IRequestHandler<GetBookRequest, Result<Book>>
{
    public async Task<Result<Book>> Handle(GetBookRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id);

        if (book is null)
            return Result.Fail(Errors.EntityNotFound<Book>(request.Id));

        return Result.Ok(book);
    }
}
