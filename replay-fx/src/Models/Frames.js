const Hit = props => ({
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

const Bump = props => ({
	frameNumber: props.frameNumber,
	attackerId: props.attackerId.id,
	victimId: props.victimId.id,
	isDemo: props.isDemo
})

const BallCarry = props => ({
	startFrameNumber: props.startFrameNumber,
	endFrameNumber: props.endFrameNumber,
})

const Goal = (props) => ({
	frameNumber: props.frameNumber,
	playerId: props.playerId.id
})

const Demo = (props) => ({
	frameNumber: props.frameNumber,
	attackerId: props.attackerId.id,
	victimId: props.victimId.id,
})

const Kickoff = (props) => ({
	startFrameNumber: props.startFrameNumber,
	endFrameNumber: props.endFrameNumber,
})

export default {
	Hit,
	Bump,
	BallCarry,
	Goal,
	Demo,
	Kickoff
}