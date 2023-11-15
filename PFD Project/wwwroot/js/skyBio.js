
function FCClientJS(apiKey, apiSecret) {
	var _server = "http://api.skybiometry.com/fc/";
	var _format = "json";

	var _apiKey = null;
	var _apiSecret = null;

	if (isDefined(apiKey))
		_apiKey = apiKey;
	if (isDefined(apiSecret))
		_apiSecret = apiSecret;

	// Public methods

	this.facesDetect = function (urls, files, options, callback) {
		var method = "faces/detect";
		var params = {};

		if (isDefined(urls)) {
			params.urls = urls;
		}

		if (isDefined(options)) {
			if (isDefined(options.detector) && !isEmpty(options.detector)) params.detector = options.detector;
			if (isDefined(options.attributes) && !isEmpty(options.attributes)) params.attributes = options.attributes;
			if (isDefined(options.detect_all_feature_points) && !isEmpty(options.detect_all_feature_points)) params.detect_all_feature_points = options.detect_all_feature_points;
		}
		CallMethod(method, files, params, callback);
		return true;
	};

	this.facesGroup = function (userIds, urls, files, options, callback) {
		var method = "faces/group";
		var params = { uids: userIds };

		if (isDefined(urls)) {
			params.urls = urls;
		}

		if (isDefined(options)) {
			if (isDefined(options.namespace) && !isEmpty(options.namespace)) params.namespace = options.namespace;
			if (isDefined(options.detector) && !isEmpty(options.detector)) params.detector = options.detector;
			if (isDefined(options.attributes) && !isEmpty(options.attributes)) params.attributes = options.attributes;
			if (isDefined(options.threshold) && !isEmpty(options.threshold)) params.threshold = options.threshold;
			if (isDefined(options.limit) && !isEmpty(options.limit)) params.limit = options.limit;
			if (isDefined(options.return_similarities) && !isEmpty(options.return_similarities)) params.return_similarities = options.return_similarities;
			if (isDefined(options.detect_all_feature_points) && !isEmpty(options.detect_all_feature_points)) params.detect_all_feature_points = options.detect_all_feature_points;
		}

		CallMethod(method, files, params, callback);
		return true;
	};

	this.facesRecognize = function (userIds, urls, files, options, callback) {
		var method = "faces/recognize";
		var params = { uids: userIds };

		if (isDefined(urls))
			params.urls = urls;

		if (isDefined(options)) {
			if (isDefined(options.namespace) && !isEmpty(options.namespace)) params.namespace = options.namespace;
			if (isDefined(options.detector) && !isEmpty(options.detector)) params.detector = options.detector;
			if (isDefined(options.attributes) && !isEmpty(options.attributes)) params.attributes = options.attributes;
			if (isDefined(options.limit) && !isEmpty(options.limit)) params.limit = options.limit;
			if (isDefined(options.detect_all_feature_points) && !isEmpty(options.detect_all_feature_points)) params.detect_all_feature_points = options.detect_all_feature_points;
		}

		CallMethod(method, files, params, callback);
		return true;
	};

	this.facesTrain = function (userIds, options, callback) {
		var method = "faces/train";
		var params = { uids: userIds };

		if (isDefined(options)) {
			if (isDefined(options.namespace) && !isEmpty(options.namespace)) params.namespace = options.namespace;
		}

		CallMethod(method, null, params, callback);
		return true;
	};

	this.facesStatus = function (userIds, options, callback) {
		var method = "faces/status";
		var params = { uids: userIds };

		if (isDefined(options)) {
			if (isDefined(options.namespace) && !isEmpty(options.namespace)) params.namespace = options.namespace;
		}

		CallMethod(method, null, params, callback);
		return true;
	};

	this.tagsAdd = function (userId, url, x, y, width, height, options, callback) {
		var method = "tags/add";

		var params = {
			url: url,
			uid: userId,
			x: x,
			y: y,
			width: width,
			height: height
		};

		if (isDefined(options)) {
			if (isDefined(options.label) && !isEmpty(options.label)) params.label = options.label;
			if (isDefined(options.password) && !isEmpty(options.password)) params.password = options.password;
		}

		CallMethod(method, null, params, callback);
		return true;
	};


	this.tagsSave = function (tagIds, userId, options, callback) {
		var method = "tags/save";
		var params = { tids: tagIds, uid: userId };

		if (isDefined(options)) {
			if (isDefined(options.namespace) && !isEmpty(options.namespace)) params.namespace = options.namespace;
			if (isDefined(options.label) && !isEmpty(options.label)) params.label = options.label;
			if (isDefined(options.password) && !isEmpty(options.password)) params.password = options.password;
		}

		CallMethod(method, null, params, callback);
		return true;
	};

	this.tagsRemove = function (tagIds, options, callback) {
		var method = "tags/remove";
		var params = { tids: tagIds };

		if (isDefined(options)) {
			if (isDefined(options.password) && !isEmpty(options.password)) params.password = options.password;
		}

		CallMethod(method, null, params, callback);
		return true;
	};

	this.tagsGet = function (userIds, urls, photoIds, options, callback) {
		var method = "tags/get";
		var params = { uids: userIds, urls: urls, pids: photoIds };

		if (isDefined(options)) {
			if (isDefined(options.order) && !isEmpty(options.order)) params.order = options.order;
			if (isDefined(options.limit) && !isEmpty(options.limit)) params.limit = options.limit;
			if (isDefined(options.together) && !isEmpty(options.together)) params.together = options.together;
			if (isDefined(options.filter) && !isEmpty(options.filter)) params.filter = options.filter;
			if (isDefined(options.namespace) && !isEmpty(options.namespace)) params.namespace = options.namespace;
		}

		CallMethod(method, null, params, callback);
		return true;
	};

	this.accountAuthenticate = function (options, callback) {
		var method = "account/authenticate";
		var params = {};

		CallMethod(method, null, params, callback);
		return true;
	};

	this.accountUsers = function (namespaces, options, callback) {
		var method = "account/users";
		var params = { namespaces: namespaces };

		CallMethod(method, null, params, callback);
		return true;
	};

	this.accountNamespaces = function (options, callback) {
		var method = "account/namespaces";
		var params = {};

		CallMethod(method, null, params, callback);
		return true;
	};

	this.accountLimits = function (options, callback) {
		var method = "account/limits";
		var params = {};

		CallMethod(method, null, params, callback);
		return true;
	};

	this.getServer = function () {
		return _server;
	}

	this.setServer = function (server) {
		_server = server;
	}

	// Private methods

	function isDefined(s) { return (typeof s != "undefined" && s != undefined); }
	function isEmpty(s) { return (!isDefined(s) || s == null || s == ''); }

	function GetXmlHttpRequest() {
		var xmlhttp = false;
		/*@cc_on @*/
		/*@if (@_jscript_version >= 5)
		// JScript gives us Conditional compilation, we can cope with old IE versions.
		// and security blocked creation of the objects.
		 try {
		  xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
		 } catch (e) {
		  try {
		   xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
		  } catch (E) {
		   xmlhttp = false;
		  }
		 }
		@end @*/
		if (!xmlhttp && typeof XMLHttpRequest != 'undefined') {
			try {
				xmlhttp = new XMLHttpRequest();
			} catch (e) {
				xmlhttp = false;
			}
		}
		if (!xmlhttp && window.createRequest) {
			xmlhttp = window.createRequest();
		}
		return xmlhttp;
	}

	function CallMethod(method, files, params, callback) {
		var url = _server + method + "." + _format;

		if (!isDefined(files)) {
			url += "?api_key=" + encodeURIComponent(_apiKey);
			if (isDefined(_apiSecret) && !isEmpty(_apiSecret)) {
				url += "&api_secret=" + encodeURIComponent(_apiSecret);
			}

			if (params != null) {
				for (param in params)
					url += "&" + param + "=" + encodeURIComponent(params[param]);
			}

			var request = Math.round(Math.random() * 10000000);
			var callbackName = "jsonp" + request;
			var responceId = "fcClientJsResponse" + request;
			window[callbackName] = function (data) {
				document.getElementById(responceId).parentNode.removeChild(document.getElementById(responceId));
				if (typeof callback == "function") {
					callback(data);
				}
			};
			url += "&callback=" + callbackName + "&" + request;

			var script = document.createElement("script");
			script.setAttribute("src", url);
			script.setAttribute("type", "text/javascript");
			script.setAttribute("id", responceId);
			document.body.appendChild(script);
		} else {
			var xhr = GetXmlHttpRequest();
			xhr.open("POST", url, true);

			if (params == null) params = {};
			params.api_key = _apiKey;
			if (isDefined(_apiSecret)) params.api_secret = _apiSecret;

			if (typeof FormData == 'undefined')
				throw "Only FormData is supported";

			var body = new FormData();
			for (param in params) {
				body.append(param, params[param]);
			}

			for (file in files) {
				body.append(file, files[file]);
			}

			xhr.onreadystatechange = function () {
				if (xhr.readyState == 4) {
					if (xhr.status == 200 || xhr.status == 400) {
						if (typeof callback == "function") {
							callback(xhr.responseText);
						}
					}
					else throw "Invalid status returned from API server";
				}
			}

			xhr.send(body);
		}
	}
}
$(function () {
	function drawFacesAddPoint(control, imgWidth, imgHeight, point, title) {
		var x = Math.round(point.x * imgWidth / 100);
		var y = Math.round(point.y * imgHeight / 100);
		var pointClass = title == null ? "api_face_all_point" : "api_face_point";
		var pointStyle = 'top: ' + y + 'px; left: ' + x + 'px;';
		var pointTitle = (title == null ? '' : title + ': ') + 'X=' + x + ', Y=' + y + ', Confidence=' + point.confidence + '%' + (title == null ? ', Id=' + point.id.toString(16) : '');
		control.append($('<span class="' + pointClass + '" style="' + pointStyle + '" title="' + pointTitle + '"></span>'));
	}
	function drawFaces(div, photo, drawPoints) {
		if (!photo) {
			alert("No image found");
			return;
		}
		if (photo.error_message) {
			alert(photo.error_message);
			return;
		}
		var imageWrapper = $('<div class="image_wrapper"></div>').appendTo(div);
		var maxImgWidth = parseInt(div.prev().children(".img_max_width").html(), 10);
		var maxImgHeight = parseInt(div.prev().children(".img_max_height").html(), 10);
		var imgWidth = photo.width;
		var imgHeight = photo.height;
		var scaleFactor = Math.min(maxImgWidth / imgWidth, maxImgHeight / imgHeight);
		if (scaleFactor < 1) {
			imgWidth = Math.round(imgWidth * scaleFactor);
			imgHeight = Math.round(imgHeight * scaleFactor);
		}
		imageWrapper.append($('<img alt="face detection results" width="' + imgWidth + 'px" height="' + imgHeight + 'px" src="' + photo.url + '" />'));
		if (photo.tags) {
			for (var i = 0; i < photo.tags.length; ++i) {
				var tag = photo.tags[i];
				var tagWidth = tag.width * 1.5;
				var tagHeight = tag.height * 1.5;
				var width = Math.round(tagWidth * imgWidth / 100);
				var height = Math.round(tagHeight * imgHeight / 100);
				var left = Math.round((tag.center.x - 0.5 * tagWidth) * imgWidth / 100);
				var top = Math.round((tag.center.y - 0.5 * tagHeight) * imgHeight / 100);
				if (drawPoints && tag.points) {
					for (var p = 0; p < tag.points.length; p++) {
						drawFacesAddPoint(imageWrapper, imgWidth, imgHeight, tag.points[p], null);
					}
				}
				var tagStyle = 'top: ' + top + 'px; left: ' + left + 'px; width: ' + width + 'px; height: ' + height + 'px; transform: rotate(' +
					tag.roll + 'deg); -ms-transform: rotate(' + tag.roll + 'deg); -moz-transform: rotate(' + tag.roll + 'deg); -webkit-transform: rotate(' +
					tag.roll + 'deg); -o-transform: rotate(' + tag.roll + 'deg)';
				var apiFaceTag = $('<div class="api_face" style="' + tagStyle + '"><div class="api_face_inner"><div class="api_face_inner_tid" name="' + tag.tid + '"></div></div></div>').appendTo(imageWrapper);
				if (drawPoints) {
					if (tag.eye_left) drawFacesAddPoint(imageWrapper, imgWidth, imgHeight, tag.eye_left, "Left eye");
					if (tag.eye_right) drawFacesAddPoint(imageWrapper, imgWidth, imgHeight, tag.eye_right, "Right eye");
					if (tag.mouth_center) drawFacesAddPoint(imageWrapper, imgWidth, imgHeight, tag.mouth_center, "Mouth center");
					if (tag.nose) drawFacesAddPoint(imageWrapper, imgWidth, imgHeight, tag.nose, "Nose tip");
				}
			}
		}
	}
	function callback(data) {
		drawFaces($("#conent_demo_image"), data.photos[0], true);
	}
	const apiKey = "hsoq6f8u8ac1gh6hdcs3n5ovh4";
	const apiSecret = "erlr02evumik5n970jgs9h5ivo";
	var client = new FCClientJS(apiKey, apiSecret);
	var options = new Object();
	options.detect_all_feature_points = true;

	//for every 2 seconds call face detech
	var result = client.facesDetect("https://res.cloudinary.com/demo/image/upload/c_crop,g_face/woman.jpg", null, options, callback);
	Console.log(result)
});