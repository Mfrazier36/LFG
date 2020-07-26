export const Hits = props => (
	{
		frameNumber: props.frameNumber,
		playerId: props.playerId.id,
		collisionDistance: props.collisionDistance,
		ballPosX: props.ballData.posX,
		ballPosY: props.ballData.posY,
		ballPosZ: props.ballData.posZ,
		distance: props.distance,
		distanceToGoal: props.distanceToGoal,
		previousHitFrameNumber: props.previousHitFrameNumber,
		nextHitFrameNumber: props.nextHitFrameNumber,
		goalNumber: props.goalNumber,
		isKickoff: props.isKickoff,
		clear: props.clear
	})

	export const Bumps = props => ({
		frameNumber: props.frameNumber,
		attackerId: props.attackerId.id,
		victimId: props.victimId.id,
		isDemo: props.isDemo
	})

	export const BallCarries = props => ({
		startFrameNumber: props.startFrameNumber,
		endFrameNumber: props.endFrameNumber,
		playerId: props.playerId.id,
		carryTime: props.carryTime,
		averageCarrySpeed: props.carryStats.averageCarrySpeed,
		carryDistance: props.carryStats.distanceAlongPath
	})

	export const Goal = (props) => ({
		frameNumber: props.frameNumber,
		playerId: props.playerId.id
	});
	
	export const Demo = (props) => ({
		frameNumber: props.frameNumber,
		attackerId: props.attackerId.id,
		victimId: props.victimId.id,
	});