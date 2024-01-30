const settings = {
	async: true,
	crossDomain: true,
	url: 'https://lua-the-ai-translator.p.rapidapi.com/translate',
	method: 'POST',
	headers: {
		'content-type': 'text/plain',
		'X-RapidAPI-Key': 'edc478d32emsha51e20860275fe4p1daa84jsn1bd6d508d2f6',
		'X-RapidAPI-Host': 'lua-the-ai-translator.p.rapidapi.com'
	},
	data: '{
"text": "J\'adore Lua, C\'est tres bien pour la traductions!"
}'
};

$.ajax(settings).done(function (response) {
	console.log(response);
});