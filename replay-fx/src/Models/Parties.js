export const partiesData = props => ({
	leaderId: props.leaderId,
	memberIds: props.members.map(player => player.id)
})