using Sandbox;

/// <summary>
/// Over-the-shoulder third person camera for the built-in PlayerController.
/// Put this on the SAME GameObject that has the PlayerController.
/// </summary>
[Title( "Third Person Player Script" )]
[Category( "Minigames" )]
[Icon( "videocam" )]
public sealed class ThirdPersonPlayerScript : Component
{
	/// <summary>The player controller. If empty, it is found automatically.</summary>
	[Property] public PlayerController Controller { get; set; }

	/// <summary>How far the camera is behind the player.</summary>
	[Property, Range( 50, 400 )] public float Distance { get; set; } = 180f;
	[Property] public float MinDistance { get; set; } = 80f;
	[Property] public float MaxDistance { get; set; } = 350f;

	/// <summary>Side offset. Positive = right shoulder, negative = left shoulder.</summary>
	[Property, Range( -60, 60 )] public float ShoulderOffset { get; set; } = 25f;

	/// <summary>Extra camera height.</summary>
	[Property, Range( -30, 60 )] public float Height { get; set; } = 10f;

	/// <summary>How much one mouse wheel step zooms in or out.</summary>
	[Property] public float ZoomSpeed { get; set; } = 20f;

	protected override void OnStart()
	{
		Controller ??= GetComponent<PlayerController>();
		if ( Controller is null )
		{
			Log.Warning( "ThirdPersonPlayerScript: no PlayerController found on this GameObject." );
			return;
		}

		Controller.ThirdPerson = true;
		ApplyCamera();
	}

	protected override void OnUpdate()
	{
		// Only the owner controls their own camera (important in multiplayer)
		if ( IsProxy || Controller is null ) return;

		var wheel = Input.MouseWheel.y;
		if ( wheel != 0 )
			Distance = (Distance - wheel * ZoomSpeed).Clamp( MinDistance, MaxDistance );

		ApplyCamera();
	}

	void ApplyCamera()
	{
		// x = distance behind, y = side, z = height
		Controller.CameraOffset = new Vector3( Distance, ShoulderOffset, Height );
	}
}
