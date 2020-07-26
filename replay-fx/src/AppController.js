import React from 'react';
import $, { data } from 'jquery';

function UploadFile(props) {
	$.post('XXXX.com',({
		success: data => {
			console.log(data)
		},
		error: data => {
			console.log(data)
		}
	}))
}