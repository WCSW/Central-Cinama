(function() {
  function initPlugin() {
    var playRoot = $(".videoFrame");
    if(playRoot.length > 0) {
      playRoot.each(function(thisIndex, thisElement) {
				$(this).on("click", function() {
          
          var thisIdValue = $(this).attr("id");
					var thisVideoParent = $('*[data-position="#' + thisIdValue + '"]');
					setTimeout(function() {
						thisVideoParent.removeClass("hiddenTransform");
					}, 500);

					var playThisVideo = $('*[data-selection="#' + thisIdValue + '"]');
					playThisVideo[0].src += "&autoplay=1";

					if(thisVideoParent.find('*[data-closer="#' + thisIdValue + '"]').length > 0) {
						var closeButton = thisVideoParent.find('*[data-closer="#' + thisIdValue + '"]');
						closeButton.on("click", function() {
							var currentVideoSrc = playThisVideo.attr("src");
							var stopThisVideoUrl = currentVideoSrc.split("&autoplay=1")[0];
							playThisVideo[0].src = stopThisVideoUrl + "&autoplay=0";
							playThisVideo[0].src = stopThisVideoUrl;
							thisVideoParent.addClass("hiddenTransform");
						});
					}
					else {
						console.error("WARNING: Close Button is unavailable for stopping the video, please insert necessary dom!");
						return;
					}
				});
      });
    }
  }

  function applicationCentralController() {
    initPlugin();
  }

  $(document).ready(function() {
    applicationCentralController();
  });
})();
