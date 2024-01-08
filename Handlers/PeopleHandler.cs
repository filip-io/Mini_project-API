using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_project_API.Data;
using Mini_project_API.Models;
using Mini_project_API.Models.DTO;
using Mini_project_API.Models.ViewModels;
using System.Net;

namespace Mini_project_API.Handlers
{
    public class PeopleHandler
    {
        public static IResult GetPeople(ApplicationContext context, SearchDto? userQuery)
        {
            if (userQuery != null)
            {
                // Filter results by provided string from user
                return UseSearch(context, userQuery);
            }

            PeopleViewModel[] unfilteredResult = context.People
                    .Select(p => new PeopleViewModel()
                    {
                        Id = p.Id,
                        Name = $"{p.FirstName} {p.LastName}",
                    })
                    .ToArray();

            if (unfilteredResult.Length < 1)
            {
                // If no interests are found
                return Results.NotFound("No people found.");
            }

            return Results.Json(unfilteredResult);
        }

        private static IResult UseSearch(ApplicationContext context, SearchDto userQuery)
        {
            PeopleViewModel[] filteredResult = context.People
                .Where(p => p.FirstName.StartsWith(userQuery.Search))
                .Select(p => new PeopleViewModel()
                {
                    Id = p.Id,
                    Name = $"{p.FirstName} {p.LastName}",
                })
                .ToArray();

            if (filteredResult.Length < 1)
            {
                return Results.NotFound(new { Message = $"No person with first name that begins with {userQuery} found. Please try again." });
            }

            return Results.Json(filteredResult);
        }

        public static IResult GetPeoplePagination(ApplicationContext context, int pageNumber, int pageSize)
        {
            if (pageSize < 1) 
            {
                return Results.BadRequest(new { Error = $"Parameter 'pageSize' cannot be zero. Please choose a higher number." });
            }

            int totalPeople = context.People.Count();
            int maxPages = (int)Math.Ceiling((decimal)totalPeople / pageSize);

            if (pageNumber < 1 || pageNumber > maxPages)
            {
                // Display if invalid page number is provided
                return Results.BadRequest(new { Error = $"Invalid page number. Maximum available page number is: {maxPages}. Please choose another page number." });
            }

            int skipCount = (pageNumber - 1) * pageSize;

            PeopleViewModel[] result = context.People
                                              .OrderBy(p => p.Id)
                                              .Skip(skipCount)
                                              .Take(pageSize)
                                              .Select(p => new PeopleViewModel()
                                              {
                                                  Id = p.Id,
                                                  Name = $"{p.FirstName} {p.LastName}",
                                              })
                                              .ToArray();

            return Results.Json(result);
        }

        public static IResult AddPerson(ApplicationContext context, PersonDto person)
        {
            context.People.Add(new Person()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber
            });

            context.SaveChanges();

            return Results.Ok(new { Message = "Person successfully added." } );
        }

        public static IResult GetPersonInterestLinks(ApplicationContext context, int personId)
        {
            var result = context.InterestLinks
                                .Where(il => il.Person.Id == personId)
                                .Select(il => il.Url)
                                .ToArray();

            if (result.Length < 1)
            {
                // If no interests are found
                return Results.NotFound( new { Message = "No links found." } );
            }

            return Results.Json(result);
        }

        public static IResult GetPersonHierarchical(ApplicationContext context, int personId)
        {
            try
            {
                var person = context.People
                                    .Where(p => p.Id == personId)
                                    .Include(p => p.Interests)
                                    .Include(p => p.InterestLinks)
                                    .SingleOrDefault();

                if (person == null)
                {
                    // Display if no person or interest with provided Id is found
                    return Results.NotFound(new { Message = $"Person with ID: {personId} not found." } );
                }

                var hierarchical = new PersonHierarchicalViewModel()
                {
                    Name = $"{person.FirstName} {person.LastName}",
                    Interests = person.Interests.Select(i => i.Name).ToArray(),
                    InterestLinks = person.InterestLinks.Select(il => il.Url).ToArray()
                };

                return Results.Json(hierarchical);
            }
            catch
            {
                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}