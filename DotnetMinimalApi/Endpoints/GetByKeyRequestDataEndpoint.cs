using DotnetMinimalApi.Entities;
using Marten;

namespace DotnetMinimalApi.Endpoints
{
    public static class GetByKeyRequestDataEndpoint
    {
        public static void GetByKeyRequestData(this IEndpointRouteBuilder app)
        {
            app.MapGet("/requestdata/{key}", async (string key, IDocumentSession session) =>
            {
                var data = await session.Query<RequestData>().FirstOrDefaultAsync(x => x.Key == key);

                if (data is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(data);
            });
        }
    }
}
