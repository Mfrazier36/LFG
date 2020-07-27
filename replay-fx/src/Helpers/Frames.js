import Template from '../Models/Frames';
import PlayerTemplate from '../Models/Player';
import { KickoffStats, PlayerKickoffStats } from '../Models/Kickoff';
import MatchTemplate from '../Models/Match';
import BallTemplate from '../Models/Ball';
import TeamTemplate from '../Models/Team';

function extractFrameData(data) {
	var gamestats = data.gameStats;
	var gamemetadata = data.gameMetadata;

	const goals = gamemetadata.goals;
	const demos = gamemetadata.demos;
	const hits = gamestats.hits;
	const bumps = gamestats.bumps;
	const carries = gamestats.ballCarries;
	const kickoffs = gamestats.kickoffs;

	const goalFrames = goals.map(frame => Template.Goal(frame));
	const demoFrames = demos.map(frame => Template.Demo(frame));
	const hitFrames = hits.map(frame => Template.Hit(frame));
	const bumpFrames = bumps.map(frame => Template.Bump(frame));
	const carryFrames = carries.map(frame => Template.BallCarry(frame));
	const kickoffFrames = kickoffs.map(frame => Template.Kickoff(frame));

	return ({
		Goals: goalFrames,
		Demos: demoFrames,
		Hits: hitFrames,
		Bumps: bumpFrames,
		Carries: carryFrames,
		Kickoffs: kickoffFrames
	})
}

function extractPlayerData(data) {
	var players = data.players;

	const playerList = data.players.map(playerData => PlayerTemplate(playerData))

	return ({
		PlayerData: playerList
	})
}

function extractPartyData(data) {
	var party = data.parties;

	const partyMemberIds = party.memberIds.map(player => player.id);
	const leaderId = party.leaderId;

	return ({
		LeaderId: leaderId,
		MemberIds: partyMemberIds
	})
}

function extractTeamData(data) {
	var teamData = data.team;

	const teamStats = TeamTemplate(teamData);

	return ({
		TeamStats: teamStats
	})
}

function extractKickoffData(data) {
	var kickOffs = data.gameData.kickOffStats;

	const playerKickoffStats = [];
	const kickoffStats = [];

	kickOffs.map(stats => {
		kickoffStats.push(KickoffStats(stats))
		stats.touch.players.map(stats => (
			playerKickoffStats.push(PlayerKickoffStats(stats))
		))
	})

	return ({
		KickOffStats: kickoffStats,
		PlayerKickoffStats: playerKickoffStats
	})
}

function extractMatchData(data) {
	var metaData = data.gameMetadata;

	var matchData = MatchTemplate(metaData);

	return ({
		MatchStats: matchData
	})
}

function extractBallData(data) {
	var ballData = data.gameStats.ballStats;

	const ballStats = BallTemplate(ballData);

	return ({
		BallStats: ballStats
	})
}

export default {
	extractFrameData,
	extractPlayerData,
	extractKickoffData,
	extractMatchData,
	extractPartyData,
	extractTeamData,
	extractBallData
}