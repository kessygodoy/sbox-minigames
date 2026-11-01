using Sandbox;

/// <summary>
/// Prints the player's state once per second to the Console.
/// Remove this component when you no longer need it.
/// </summary>
[Title( "Player Debug" )]
[Category( "Minigames" )]
public sealed class PlayerDebug : Component
{
	[Property] public PlayerController Controller { get; set; }

	TimeSince _timeSinceLastLog;

	protected override void OnStart()
	{
		Controller ??= GetComponent<PlayerController>();
	}

	protected override void OnUpdate()
	{
		if ( IsProxy || Controller is null ) return;
		if ( _timeSinceLastLog < 1f ) return;

		_timeSinceLastLog = 0;

		var velocity = Controller.Body.IsValid() ? Controller.Body.Velocity : Vector3.Zero;
		Log.Info( $"Position: {WorldPosition} | OnGround: {Controller.IsOnGround} | Wish: {Controller.WishVelocity} | Velocity: {velocity}" );
	}
}
