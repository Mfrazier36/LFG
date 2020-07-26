import { Goal, Demo } from './_FrameTemplates';

export const matchData = props => ({
		id: props.id,
		version: props.version,
		name: props.name,
		map: props.map,
		playlist: props.playlist,
		time: props.time,
		totalFrames: props.frames,
		length: props.length,
		gameServerId: props.gameServerId,
		serverName: props.serverName,
		matchGuid: props.matchGuid,
		teamSize: props.teamSize,
		primaryPlayer: props.primaryPlayer.id,
		team0Score: props.score.team0Score,
		team1Score: props.score.team1Score,
		goals: props.goals.map(goalData => Goal(goalData)),
		demos: props.demos.map(demoData => Demo(demoData)),
})
