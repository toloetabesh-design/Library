using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Library.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<BookService> _logger;

    public BookService(
        IBookRepository bookRepository,
        IMapper mapper,
        ILogger<BookService> logger)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<BookDto>> GetAllAsync()
    {
        _logger.LogInformation("Getting all books");

        var books = await _bookRepository.GetAllAsync();

        _logger.LogInformation("Books retrieved successfully");

        return _mapper.Map<List<BookDto>>(books);
    }

    public async Task<BookDto> GetByIdAsync(int id)
    {
        _logger.LogInformation("Getting book with Id: {Id}", id);

        var book = await _bookRepository.GetByIdAsync(id);

        return _mapper.Map<BookDto>(book);
    }

    public async Task AddAsync(BookDto bookDto)
    {
        _logger.LogInformation("Adding a new book: {Title}", bookDto.Title);

        var book = _mapper.Map<Book>(bookDto);

        await _bookRepository.AddAsync(book);

        _logger.LogInformation("Book added successfully");
    }

    public async Task UpdateAsync(BookDto bookDto)
    {
        _logger.LogInformation("Updating book with Id: {Id}", bookDto.Id);

        var book = _mapper.Map<Book>(bookDto);

        await _bookRepository.UpdateAsync(book);

        _logger.LogInformation("Book updated successfully");
    }

    public async Task DeleteAsync(int id)
    {
        _logger.LogInformation("Deleting book with Id: {Id}", id);

        await _bookRepository.DeleteAsync(id);

        _logger.LogInformation("Book deleted successfully");
    }
}