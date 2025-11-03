// Fix for MudBlazor drawer height calculation
window.mudElementRef = {
    getBoundingClientRect: function() {
        console.log("Custom getBoundingClientRect called");
        // Return default values that should work for most cases
        return {
            bottom: 800,
            height: 800,
            left: 0,
            right: 1200,
            top: 0,
            width: 1200,
            x: 0,
            y: 0
        };
    }
};

// Initialize on page load
document.addEventListener('DOMContentLoaded', function() {
    console.log("MudBlazor fix initialized");
});
