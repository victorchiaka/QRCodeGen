// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var body = document.querySelector("body");

// body.style.backgroundImage = 'url("/images/one-person-standing-determined-extreme-adventure-generated-by-ai.jpg")';

body.style.transition = "2s ease-in-out";

function changeBackground() {
    const images = [
        'url("images/awesome.jpg")',
        'url("images/dew.jpg")',
        'url("images/nature1.jpg")',
        'url("images/nature2.jpg")',
        'url("images/quintin.jpg")',
        'url("images/pexels.jpg")',
        'url("images/marek-piwnicki.jpg")',
        'url("images/galactic-night.jpg")'
    ];

    {
        const backgroundImage = images[Math.floor(Math.random() * images.length)];
        body.style.background = backgroundImage;
        body.style.backgroundAttachment = "fixed";
        body.style.backgroundPosition = "center";
        body.style.backgroundSize = "cover";
    }
}

setInterval(changeBackground, 5000);