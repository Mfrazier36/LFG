const BallCarry = props => ({
	playerId: props.playerId.id,
	carryTime: props.carryTime,
	averageCarrySpeed: props.carryStats.averageCarrySpeed,
	carryDistance: props.carryStats.distanceAlongPath
})

export default BallCarry;
