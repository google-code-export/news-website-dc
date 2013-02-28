// Avoid `console` errors in browsers that lack a console.
(function() {
    var method;
    var noop = function () {};
    var methods = [
        'assert', 'clear', 'count', 'debug', 'dir', 'dirxml', 'error',
        'exception', 'group', 'groupCollapsed', 'groupEnd', 'info', 'log',
        'markTimeline', 'profile', 'profileEnd', 'table', 'time', 'timeEnd',
        'timeStamp', 'trace', 'warn'
    ];
    var length = methods.length;
    var console = (window.console = window.console || {});

    while (length--) {
        method = methods[length];

        // Only stub undefined methods.
        if (!console[method]) {
            console[method] = noop;
        }
    }
}());

// Core
var settings = {
	date: {
		dateFormat: "{yyyy}/{MM}/{dd}"
	},
	effect: {
		speed: {
			fast: 100,
			medium: 400,
			slow: 800	
		}
	}
};

var util = {
	string: {
		createUUID: function() {
			// http://www.ietf.org/rfc/rfc4122.txt
			var s = [];
			var hexDigits = "0123456789abcdef";
			for (var i = 0; i < 36; i++) {
				s[i] = hexDigits.substr(Math.floor(Math.random() * 0x10), 1);
			}
			s[14] = "4";  // bits 12-15 of the time_hi_and_version field to 0010
			s[19] = hexDigits.substr((s[19] & 0x3) | 0x8, 1);  // bits 6-7 of the clock_seq_hi_and_reserved to 01
			s[8] = s[13] = s[18] = s[23] = "-";
		
			var uuid = s.join("");
			return uuid;
		}
	},
	number: {
		randomFromTo: function(from, to){
		   return Math.floor(Math.random() * (to - from + 1) + from);
		}	
	},
	date: {
		getTodayDateString: function() {
			return Date.create().format(settings.date.dateFormat);
		},
		getRewindDateString: function(dateObj) {
			return Date.create().rewind(dateObj).format(settings.date.dateFormat);
		}
	},
	array: {
		fromCsv: function(csvStr) {
			if ($.trim(csvStr) == "") {
				return [];	
			}
			var arr = [];
			var rawArr = csvStr.split(",");
			for (i = 0; i < rawArr.length; i++) {
				arr.push({ value: rawArr[i] });
			}
			return arr;
		}	
	},
	object: {
		exists: function(obj) {
			return obj != undefined && obj != null;
		}	
	}
};
