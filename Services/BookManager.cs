﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookServices

    {


        private readonly IRepositoryManager  _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public BookDto CreateOneBook(BookDtoForInsertion bookDto)
        {
            var entity = _mapper.Map<Book>(bookDto);

            _manager.Book.CreateOneBook(entity);
            _manager.Save();
            return _mapper.Map<BookDto>(entity);
        }

     

        public void DeleteOneBook(int id, bool trackChanges)
        {

            //check entity
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
            {
                
  throw new BookNotFoundException(id);
            }
              
            _manager.Book.DeleteOneBook(entity);
            _manager.Save();



        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {
          var books = _manager.Book.GetAllBooks(trackChanges); 

            return _mapper.Map<IEnumerable<BookDto>>(books);

        }

        public BookDto GetOneBookById(int id, bool trackChanges)
        {
            var book = _manager.Book.GetOneBookById(id,trackChanges);
            if (book is null) throw new BookNotFoundException(id);
            return _mapper.Map<BookDto>(book);
        }

        public void UpdateOneBook(int id, BookDtoForUpdate bookDto,bool trackChanges)
        {
            //check entity
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
            {
               // string mesaj = $"Book with id :  {id} could not found";
               // _logger.LogInfo(mesaj );    
  throw new BookNotFoundException(id);
            }
              


            // check params
         //   if (bookDto is null) { 
           // throw new ArgumentNullException(nameof (bookDto));

            //}

            // Mapping
       //     entity.Title=book.Title;
        //    entity.Price=book.Price;

            entity=_mapper.Map<Book>(bookDto);

            _manager.Book.Update(entity);
            _manager.Save();
        }
    }
}

