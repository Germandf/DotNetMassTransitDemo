﻿using BookStore.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Features.Books.UpdateBookInfo;

[Tags("Books")]
public class UpdateBookInfoController : ApiControllerBase
{
    public UpdateBookInfoController(ISender mediator, ProblemDetailsFactory problemDetailsFactory) : base(mediator, problemDetailsFactory)
    {
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPatch("books/{id}/info", Name = nameof(UpdateBookInfo))]
    public async Task<IActionResult> UpdateBookInfo(
        [Required][FromRoute] Guid id,
        [Required][FromBody] UpdateBookInfoRequestDto dto)
    {
        var request = dto.AsRequest(id);
        var result = await _mediator.Send(request);
        return ToHttpResponse(result);
    }
}
