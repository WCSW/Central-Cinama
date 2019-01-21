using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SuperMovie.Dtos;
using SuperMovie.Models;

namespace SuperMovie.Controllers.API

{
    [System.Web.Mvc.Authorize(Roles = RoleName.CanManageMovies)]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new  ApplicationDbContext();
            
        }


        // Get/api/customers

        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include( c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomersDto>);

            return Ok(customerDtos);
        }

        //Get/api/Customers/1

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();


            return Ok( Mapper.Map<Customer, CustomersDto>(customer) );
        }



        //POST/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomersDto customerDto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();


            }

            var customer = Mapper.Map<CustomersDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto );
        }




        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomersDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
