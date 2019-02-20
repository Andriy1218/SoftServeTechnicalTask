using Microsoft.AspNetCore.Mvc;
using Serilog;
using SoftServerTechnicalTask.Domain.BuildingBlocks;

namespace SoftServeTechnicalTask.Application.BuildingBlocks
{
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : Entity
    {
        protected IActionResult ReturnNotFound(int entityId)
        {
            Log.Warning($"{typeof(TEntity).Name} with id={entityId} wasn't found!");
            return NotFound($"{typeof(TEntity).Name} with id={entityId} wasn't found!");
        }

        protected IActionResult ReturnConflict(TEntity entity)
        {
            Log.Warning($"{typeof(TEntity).Name} with name={entity.Name} already exists!");
            return Conflict($"{typeof(TEntity).Name} with name={entity.Name} already exists!");
        }

        protected IActionResult ReturnAcceptedDelete(TEntity entity)
        {
            Log.Information($"{typeof(TEntity).Name} with name={entity.Name} was successfully deleted!");
            return Accepted($"{typeof(TEntity).Name} with name={entity.Name} was successfully deleted!");
        }

        protected IActionResult ReturnAcceptedUpdate(TEntity entity)
        {
            Log.Information($"{typeof(TEntity).Name} with name={entity.Name} was successfully updated!");
            return Accepted($"{typeof(TEntity).Name} with name={entity.Name} was successfully updated!");
        }
    }
}
