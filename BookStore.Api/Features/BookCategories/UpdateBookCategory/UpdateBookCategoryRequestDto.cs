﻿namespace BookStore.Api.Features.BookCategories.UpdateBookCategory;

public record UpdateBookCategoryRequestDto(
    string Name,
    string Description)
{
    public UpdateBookCategoryRequest AsRequest(Guid id) => new(id, Name, Description);
}
