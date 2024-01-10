using Microsoft.EntityFrameworkCore;
using Mini_project_API.Data;
using Mini_project_API.Models;
using Mini_project_API.Models.DTO;
using Mini_project_API.Models.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Mini_project_API.Handlers
{
    public class InterestsHandler
    {
        public static IResult GetInterests(ApplicationContext context)
        {
            InterestPersonViewModel[] result =
                context.Interests
                       .Select(i => new InterestPersonViewModel()
                       {
                           Name = i.Name,
                           Description = i.Description,
                       })
                       .ToArray();

            if (result.Length < 1)
                // If no interests are found
                return Results.NotFound(new { Message = "No interests found." });

            return Results.Json(result);
        }

        public static IResult GetPersonInterests(ApplicationContext context, int personId)
        {
            Person? person = context.People
                                    .Where(p => p.Id == personId)
                                    .Include(p => p.Interests)
                                    .FirstOrDefault();

            if (person == null)
            {
                // If no person with provided Id is found
                return Results.NotFound(new { Message = $"No person with ID: {personId} found." });
            }

            if (person.Interests == null)
                // If person with provided Id has no interest
                return Results.NotFound(new { Message = $"No interest found for person with ID: {person.Id}." });

            InterestPersonViewModel[] interests =
                person.Interests
                      .Select(i => new InterestPersonViewModel()
                      {
                          Name = i.Name,
                          Description = i.Description,
                      })
                      .ToArray();

            if (interests.Length == 0)
            {
                // Display if no interest with provided Id is found e.g. the returned array is empty
                return Results.NotFound(new { Message = $"No interests found for person with ID: {personId}." });
            }

            return Results.Json(interests);
        }

        public static IResult AddInterest(ApplicationContext context, InterestDto interestName)
        {
            try
            {
                // Check if provided interest already exists
                if (context.Interests.Any(i => i.Name == interestName.Name))
                {
                    return Results.Conflict(new { Error = $"Interest '{interestName.Name}' already exists." });
                }

                context.Interests
                       .Add(new Interest()
                       {
                           Name = interestName.Name,
                           Description = interestName.Description,
                       });

                context.SaveChanges();

                return Results.Ok(new { Message = $"New interest '{interestName.Name}' successfully added." });
            }
            catch
            {
                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public static IResult AddPersonToInterest(ApplicationContext context, int personId, int interestId)
        {
            try
            {
                Interest? interest = context.Interests.FirstOrDefault(i => i.Id == interestId);

                if (interest == null)
                {
                    // Display if no interest with provided Id is found
                    return Results.NotFound($"Interest with ID: {interestId} not found.");
                }

                Person? person = context.People
                                        .Include(p => p.Interests)
                                        .FirstOrDefault(p => p.Id == personId);

                if (person == null)
                {
                    // Display if no person with provided Id is found
                    return Results.NotFound(new { Message = $"Person with ID: {personId} not found." });
                }

                if (person.Interests.Any(i => i.Id == interestId))
                {
                    // Display if person already has the interest
                    return Results.Conflict(new { Message = $"{person.FirstName} {person.LastName} already has the interest '{interest.Name}'. Please choose another interest." });
                }

                person.Interests.Add(interest);
                context.SaveChanges();

                return Results.Ok(new { Message = $"Interest '{interest.Name}' successfully added to {person.FirstName} {person.LastName}" });
            }
            catch
            {
                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public static IResult AddInterestLink(ApplicationContext context, int personId, int interestId, InterestLinkDto interestLink)
        {
            try
            {   // Get the person and it's interests
                Person? person = context.People
                                        .Where(p => p.Id == personId)
                                        .Include(p => p.Interests)
                                        .FirstOrDefault();

                if (person == null)
                {
                    return Results.NotFound(new { Message = $"No person with ID: {personId} found." });
                }

                Interest? interest = context.Interests.FirstOrDefault(i => i.Id == interestId);

                if (interest == null)
                {
                    return Results.NotFound(new { Message = $"No interest with ID: {interestId} found." });
                }

                // Check if the person has the interest with the provided interestId
                if (!person.Interests.Any(i => i.Id == interestId))
                {
                    return Results.BadRequest(new
                    {
                        Message = $"{person.FirstName} {person.LastName} does not have the interest '{interest.Name}'. " +
                                  $"Please add the interest to the person before adding the link."
                    });
                }

                /* Check if provided URL already exists for the specific person and interest    
                 * Null check to remove warning 'CS8602 - Dereference of a possibly null reference'. */
                bool urlExists = context.InterestLinks
                                        .Any(u => u.Person != null
                                               && u.Interest != null
                                               && u.Person.Id == personId
                                               && u.Interest.Id == interestId
                                               && u.Url == interestLink.Url);

                if (urlExists)
                {
                    return Results.BadRequest(new { Error = $"The URL already exists for interest '{interest.Name}" });
                }

                context.InterestLinks
                    .Add(new InterestLink()
                    {
                        Url = interestLink.Url,
                        Interest = interest,
                        Person = person
                    });

                context.SaveChanges();

                return Results.Ok(new { Message = $"New link {interestLink.Url} successfully added to {person.FirstName} {person.LastName}." });
            }
            catch
            {
                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
