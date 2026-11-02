/*
  main.js
  Core front-end behaviour for the site: preloader, sticky header on scroll,
  mobile dropdown submenus, and the back-to-top button.

  The original Edubin template relied on several extra jQuery plugins
  (slick, magnific-popup, nice-select, counterup, etc.) that this rebuilt
  site does not use, since those features (course sliders, popups, filters)
  were dropped along with the LMS/course pages. This file covers everything
  the remaining pages (Home, About, Teachers, Blog, Contact) actually need.
*/
(function ($) {
    "use strict";

    $(window).on("load", function () {
        $(".preloader").fadeOut(300);
    });

    // Sticky header: add a "sticky" class once the user scrolls past the top.
    $(window).on("scroll", function () {
        var scroll = $(window).scrollTop();
        if (scroll >= 100) {
            $(".navigation").addClass("sticky");
        } else {
            $(".navigation").removeClass("sticky");
        }

        if (scroll >= 400) {
            $(".back-to-top").fadeIn(200);
        } else {
            $(".back-to-top").fadeOut(200);
        }
    });

    // Back to top button.
    $(".back-to-top").on("click", function (e) {
        e.preventDefault();
        $("html, body").animate({ scrollTop: 0 }, 500);
    });

    // Mobile dropdown submenus: tapping a nav item with children toggles it
    // open instead of navigating away, on small screens only.
    $(".navbar-nav > li > ul.sub-menu").each(function () {
        $(this).parent().addClass("has-submenu");
    });

    $(".navbar-nav").on("click", "li.has-submenu > a", function (e) {
        if ($(window).width() < 992) {
            e.preventDefault();
            $(this).next("ul.sub-menu").slideToggle(200);
        }
    });

    // Search box toggle (kept from the original template markup).
    $("#search").on("click", function (e) {
        e.preventDefault();
        $(".search-box").fadeIn(200);
    });
    $(".search-box .closebtn").on("click", function () {
        $(".search-box").fadeOut(200);
    });

})(jQuery);
