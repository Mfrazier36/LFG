import $ from 'jquery';

function sendReplayFile(file) {
	$.ajax({
		type: 'GET',
		data: file,
		url: '',
		success: (response, status) => {

		},
		error: (error, status) => {

		},
	})
}

function sendMatchData(file) {
	$.ajax({
		type: 'POST',
		data: file,
		url: '',
		success: (response, status) => {

		},
		error: (error, status) => {

		},
	})
}

function sendTeamData(file) {
	$.ajax({
		type: 'POST',
		data: file,
		url: '',
		success: (response, status) => {

		},
		error: (error, status) => {

		},
	})
}

function sendPlayerData(file) {
	$.ajax({
		type: 'POST',
		data: file,
		url: '',
		success: (response, status) => {

		},
		error: (error, status) => {

		},
	})
}
function sendEventData(file) {
	$.ajax({
		type: 'POST',
		data: file,
		url: '',
		success: (response, status) => {

		},
		error: (error, status) => {

		},
	})
}

export default ({
	sendReplayFile,
	sendMatchData,
	sendTeamData,
	sendPlayerData,
	sendEventData
})