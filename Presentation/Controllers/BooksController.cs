﻿using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]




    public class BooksController : ControllerBase
    {

        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {



            var books = _manager.BookServices.GetAllBooks(false);
            return Ok(books);




        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {


            var book = _manager
                .BookServices
                .GetOneBookById(id, false);


            if (book == null)
            
                throw new BookNotFoundException(id);
            

            return Ok(book);


        }

        [HttpPost]
        public IActionResult CreateOnBook([FromBody] BookDtoForInsertion bookDto)
        {

            if (bookDto is null)
            {
                return BadRequest(); // 400
            }
            var book = _manager.BookServices.CreateOneBook(bookDto);

            return StatusCode(201, book);


        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] BookDtoForUpdate bookDto)
        {

            if (bookDto is null) return BadRequest();

            _manager.BookServices.UpdateOneBook(id, bookDto, true);



            return NoContent(); // 204 verecekmiş

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {


            _manager.BookServices.DeleteOneBook(id, false);

            return






                NoContent();

        }

    }
}
