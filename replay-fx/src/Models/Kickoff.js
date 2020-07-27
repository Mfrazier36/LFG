export const KickoffStats = props => ({
	startFrame: props.startFrame,
	touchFrame: props.touchFrame,
	touchTime: props.touchTime,
	kickoffGoal: props.touch.kickoffGoal,
	firstTouchPlayer: props.touch.firstTouchPlayer,
	playerStats: props.touch.players.map(player => PlayerKickoffStats(player))
})

export const PlayerKickoffStats = props => ({
	playerId: props.player.id,
	kickoffPosition: props.kickoffPosition,
	touchPosition: props.touchPosition,
	playerPositionX: props.playerPosition.posX,
	playerPositionY: props.playerPosition.posY,
	playerPositionZ: props.playerPosition.posZ,
	playerBoost: props.boost,
	ballDistance: props.ballDist,
	playerStartPositionX: props.startPosition.posX,
	playerStartPositionY: props.startPosition.posY,
	playerStartPositionZ: props.startPosition.posZ,
})
