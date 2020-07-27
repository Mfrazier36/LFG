const Ball = props => ({
		timeOnGround: props.positionalTendencies.timeOnGround,
		timeLowInAir: props.positionalTendencies.timeLowInAir,
		timeHighInAir: props.positionalTendencies.timeHighInAir,
		timeInDefendingHalf: props.positionalTendencies.timeInDefendingHalf,
		timeInAttackingHalf: props.positionalTendencies.timeInAttackingHalf,
		timeInDefendingThird: props.positionalTendencies.timeInDefendingThird,
		timeInNeutralThird: props.positionalTendencies.timeInNeutralThird,
		timeInAttackingThird: props.positionalTendencies.timeInAttackingThird,
		timeBehindBall: props.positionalTendencies.timeBehindBall,
		timeInFrontBall: props.positionalTendencies.timeInFrontBall,
		timeNearWall: props.positionalTendencies.timeNearWall,
		timeInCorner: props.positionalTendencies.timeInCorner,
		timeOnWall: props.positionalTendencies.timeOnWall,
	  averageSpeed: props.averages.averageSpeed,
})

export default Ball;
