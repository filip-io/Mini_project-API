using Mini_project_API.Data;
using Mini_project_API.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Mini_project_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            var app = builder.Build();

            // Welcome message and instructions
            app.MapGet("/", () => "Welcome to The Interests API!" +
            "\n\nPlease see README for documentation on how to use this API here: https://github.com/filip-io/Mini_project-API");

            // People
            app.MapPost("/people", PeopleHandler.GetPeople);
            app.MapGet("/people/pageNumber/{pageNumber}/pageSize/{pageSize}", PeopleHandler.GetPeoplePagination);
            app.MapGet("/people/{personId}/hierarchical", PeopleHandler.GetPersonHierarchical);
            app.MapPost("/people/add", PeopleHandler.AddPerson);

            // Interests
            app.MapGet("/interests", InterestsHandler.GetInterests);
            app.MapGet("/interests/{personId}", InterestsHandler.GetPersonInterests);
            app.MapPost("/people/{personId}/interests/{interestId}", InterestsHandler.AddPersonToInterest);

            // Links
            app.MapGet("/people/{personId}/interests", PeopleHandler.GetPersonInterestLinks);
            app.MapPost("/people/{personId}/interests/{interestId}/addLink", InterestsHandler.AddInterestLink);

            app.Run();
        }
    }
}
