using Microsoft.AspNetCore.Mvc;

namespace MyApi.Endpoints;




public static class ToDoItemsEndpoints
{
    private static async Task<IResult> GetAll(ITodoItems service)
    {
        return Results.Ok(await service.GetAllItems());
    }


    public static void RegisterToDoItemsEndpoints(this WebApplication app) {
        var group = app.MapGroup("/todoitems/");

        group.MapGet("/",  GetAll);

        group.MapGet("/{id}",
            async (int id, ITodoItems service) => {
                var item = await service.GetItem(id);
                if (item == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(item);
                }
            });

        group.MapPost("/", async (CreateTodoItem newItem,
            ITodoItems service) =>
        {
            if (newItem.Category is null) return Results.BadRequest();
            if (newItem.Title is null) return Results.BadRequest();

            var item = await service.CreateItem(newItem);
            // return Results.NoContent();
            return Results.Created($"/todoitems/{item.Id}", item);


        });

        //group.MapPut("{id}", async (int id, TodoItem item, ITodoItems service) =>
        //{
        //    if(id != item.Id) return Results.BadRequest();
        //    await service.UpdateItem(item);
        //    return Results.NoContent();
        //});

        group.MapPatch("{id}", async (int id, TodoItem item, ITodoItems service) =>
        {
            if (id != item.Id) return Results.BadRequest();
            await service.UpdateItem(item);
            return Results.NoContent();
        });

        group.MapDelete("{id}", async (int id,
            ITodoItems service) =>
        {
            await service.DeleteItem(id);
            await Task.Delay(1000);
            return Results.NoContent();
        });
    }
}
