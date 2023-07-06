using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;

namespace BrewUp.Warehouses.Domain.CommandHandlers;

public abstract class CommandHandlerBase<TCommand> : CommandHandlerAsync<TCommand> where TCommand : class, ICommand
{
	protected CommandHandlerBase(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task HandleAsync(TCommand command, CancellationToken cancellationToken = new())
	{
		cancellationToken.ThrowIfCancellationRequested();

		try
		{
			Logger.LogInformation(
				$"Processing command: {command.GetType()} - Aggregate: {command.AggregateId} - CommandId : {command.MessageId}");
			await ProcessCommand(command, cancellationToken);
		}
		catch (Exception e)
		{
			// Raising an event is a better solution!
			Logger.LogError(
				$"Error processing command: {command.GetType()} - Aggregate: {command.AggregateId} - CommandId : {command.MessageId} - Messagge: {e.Message} - Stack Trace {e.StackTrace}");
			throw;
		}
	}

	public abstract Task ProcessCommand(TCommand command, CancellationToken cancellationToken = default);
}