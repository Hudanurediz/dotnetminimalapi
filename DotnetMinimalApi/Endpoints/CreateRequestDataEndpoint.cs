using DotnetMinimalApi.Entities;
using Marten;

namespace DotnetMinimalApi.Endpoints
{
    public static class CreateRequestDataEndpoint
    {
        public static void CreateRequestData(this IEndpointRouteBuilder app)
        {
            app.MapPost("/requestdata/{key}", async (string key, RequestData requestData, IDocumentSession session) =>
            {
                if (requestData == null || string.IsNullOrEmpty(requestData.Data))
                {
                    return Results.BadRequest("Invalid data.");
                }

                requestData.Key = key;

                var existingData = await session.Query<RequestData>().FirstOrDefaultAsync(x => x.Key == requestData.Key);
                if (existingData != null)
                {
                    existingData.Data = requestData.Data;
                    session.Store(existingData);
                }
                else
                {
                    session.Store(requestData);
                }

                await session.SaveChangesAsync();

                return Results.Created($"/requestdata/{key}", requestData);
            });
        }
    }
}
