using DotnetMinimalApi.Entities;
using Marten;

namespace DotnetMinimalApi.Endpoints
{
    public static class DeleteByKeyRequestDataEndpoint
    {
        public static void DeleteByKeyRequestData(this IEndpointRouteBuilder app)
        {
            app.MapDelete("/requestdata/{key}", async (string key, IDocumentSession session) =>
            {
                var data = await session.Query<RequestData>().FirstOrDefaultAsync(x => x.Key == key);
                if (data is null)
                {
                    return Results.NotFound();
                }

                session.Delete(data);
                await session.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
