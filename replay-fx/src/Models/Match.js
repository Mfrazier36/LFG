const Match = props => ({
	matchGuid: props.matchGuid,
	replayId: props.id,
	replayVersion: props.version,
	replayName: props.name,
	gameServerId: props.gameServerId,
	gameServerName: props.serverName,
	map: props.map,
	playlist: props.playlist,
	totalTime: props.time,
	totalFrames: props.frames,
	teamSize: props.teamSize,
	team0Score: props.score.team0Score,
	team1Score: props.score.team1Score,
})

export default Match;
