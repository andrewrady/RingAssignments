// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var tabs = document.querySelector('.nav-tabs')

if (tabs) {
    var children = Array.from(tabs.children);
    children.forEach(function (tab) {
        tab.addEventListener('click', function (e) {
            e.preventDefault();
            var activePaneValue = tab.textContent.trim().toLowerCase()
            setActivePane(activePaneValue);
            setActiveTab(tabs, tab);
        })
    })
}

function setActiveTab(tabs, currentTab) {
    Array.from(tabs.children).forEach(function (x) {
        x.children[0].classList.remove('active');
    });
    currentTab.children[0].classList.add('active');
}

function setActivePane(activePane) {
    var content = document.querySelector('.tab-content');
    var tabPane = Array.from(content.children);
    tabPane.forEach(function (pane) {
        pane.classList.remove('active')
    })
    document.getElementById(activePane).classList.add('active');

}
