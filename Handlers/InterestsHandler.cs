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
                return Results.NotFound("No interests found.");

            return Results.Json(result);
        }

        public static IResult GetPersonInterests(ApplicationContext context, int personId)
        {
            var person =
                context.People
                       .Where(p => p.Id == personId)
                       .Include(p => p.Interests)
                       .FirstOrDefault();

            if (person == null)
            {
                // If no person with provided Id is found
                return Results.NotFound($"No person with ID: {personId} found.");
            }

            if (person.Interests == null)
                // If person with provided Id has no interest
                return Results.NotFound($"No interest found for person with ID: {person.Id}.");

            var interests = person.Interests
                                  .Select(i => new InterestPersonViewModel()
                                  {
                                      Name = i.Name,
                                      Description = i.Description,
                                  })
            .ToArray();

            if (interests.Length == 0)
            {
                // Display if no interest with provided Id is found e.g. the returned array is empty
                return Results.NotFound($"No interests found for person with ID: {personId}.");
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
                    return Results.Conflict($"Interest '{interestName.Name}' already exists.");
                }

                context.Interests
                    .Add(new Interest()
                    {
                        Name = interestName.Name,
                        Description = interestName.Description,
                    });

                context.SaveChanges();

                return Results.Ok($"New interest '{interestName.Name}' successfully added.");
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
                var interest = context.Interests
                                      .Where(i => i.Id == interestId)
                                      .SingleOrDefault();

                if (interest == null)
                {
                    // Display if no interest with provided Id is found
                    return Results.NotFound($"Interest with ID: {interestId} not found.");
                }

                var person = context.People
                                    .Where(p => p.Id == personId)
                                    .Include(p => p.Interests)
                                    .SingleOrDefault();

                if (person == null)
                {
                    // Display if no person or interest with provided Id is found
                    return Results.NotFound($"Person with ID: {personId} not found.");
                }

                if (person.Interests.Contains(interest))
                {
                    return Results.Conflict("Person already has that interest. Please choose another interest.");
                }

                person.Interests.Add(interest);
                context.SaveChanges();

                return Results.Ok($"Person with ID: {personId} successfully added to interest with ID: {interestId}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message} occurred while processing your request.");

                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public static IResult AddInterestLink(ApplicationContext context, int personId, int interestId, InterestLinkDto interestLink)
        {
            try
            {   // Get the person and it's interests
                var person = context.People
                                    .Where(p => p.Id == personId)
                                    .Include(p => p.Interests)
                                    .SingleOrDefault();

                if (person == null)
                {
                    return Results.NotFound($"No person with ID: {personId} found.");
                }

                var interest = context.Interests
                                            .Where(i => i.Id == interestId)
                                            .SingleOrDefault();

                if (interest == null)
                {
                    return Results.NotFound($"No interest with ID: {interestId} found.");
                }

                // Check if the person has the interest with the provided interestId
                if (!person.Interests.Any(i => i.Id == interestId))
                {
                    return Results.BadRequest($"Person with ID: {personId} does not have the interest with ID: {interestId}. " +
                                              $"Please add the interest to the person before adding the link.");
                }

                // Check if provided URL already exists for the specific person and interest
                var urlExists = context.InterestLinks
                                                           .Any(u => u.Person.Id == personId
                                                                  && u.Interest.Id == interestId
                                                                  && u.Url == interestLink.Url);

                if (urlExists)
                {
                    return Results.BadRequest("The URL already exists for the chosen interest.");
                }

                context.InterestLinks
                    .Add(new InterestLink()
                    {
                        Url = interestLink.Url,
                        Interest = interest,
                        Person = person
                    });

                context.SaveChanges();

                return Results.Ok($"New link {interestLink.Url} successfully added to person with ID: {personId}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message} occurred while processing your request.");

                return Results.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
