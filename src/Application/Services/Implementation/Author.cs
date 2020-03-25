﻿using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Domain.IRepositories;
using Entities = Domain.Entities;

namespace Application.Services.Implementation
{
    public class Author : Interfaces.IAuthor
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public Author(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> GetById(int authorId)
        {
            return _mapper.Map<AuthorDto>(await _authorRepository.FindByIdAsync(authorId));
        }

        public async Task<List<AuthorDto>> GetAll()
        {
            return _mapper.Map<List<AuthorDto>>(await _authorRepository.GetAllAsync());
        }
        public async Task<int> Add(AuthorDto authorDto)
        {
            var author = _mapper.Map<Entities.Author>(authorDto);
            _authorRepository.Add(author);
            await _authorRepository.SaveChangesAsync();
            return author.Id;
        }
        public async Task<AuthorDto> Remove(int authorId)
        {
            var author = await _authorRepository.FindByIdAsync(authorId);
            if (author == null) 
                return null;
            _authorRepository.Remove(author);
            await _authorRepository.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }
        public async Task Update(AuthorDto authorDto)
        {
            var author = _mapper.Map<Entities.Author>(authorDto);
            _authorRepository.Update(author);
            await _authorRepository.SaveChangesAsync();
        }
    }
}