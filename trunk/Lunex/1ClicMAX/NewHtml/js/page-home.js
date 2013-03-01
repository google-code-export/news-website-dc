$(function() {
	$("#productsNav li a").each(function(i) {
        $(this).hover(function() {
			$("#mainContent").hide();
			$("#homePage .product-desc").eq(i).fadeIn("fast");
		},
		function() {
			$("#homePage .product-desc").hide();
			$("#mainContent").show();
		});
    });
});