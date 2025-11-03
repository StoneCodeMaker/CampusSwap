// MudBlazor interop functions
window.mudElementRef = {};
window.mudDrawer = {
    // Function to get element dimensions
    getBoundingClientRect: function (element) {
        if (!element) {
            console.error("Element not found for getBoundingClientRect");
            return { top: 0, right: 0, bottom: 0, left: 0, width: 0, height: 0 };
        }
        return element.getBoundingClientRect();
    },
    
    // Function to register an element reference
    registerElement: function (id, element) {
        if (!element) {
            console.error("Cannot register null element");
            return;
        }
        window.mudElementRef[id] = element;
        console.log("Registered element with id:", id);
    },
    
    // Function to get a registered element
    getElement: function (id) {
        return window.mudElementRef[id];
    }
};

// Initialize MudBlazor interop
window.initMudBlazor = function () {
    console.log("MudBlazor interop initialized");
    
    // Create a dummy element to ensure mudElementRef is defined
    if (!window.mudElementRef) {
        window.mudElementRef = {};
    }
    
    // Add getBoundingClientRect if it doesn't exist
    if (!window.mudElementRef.getBoundingClientRect) {
        window.mudElementRef.getBoundingClientRect = function() {
            console.log("Default getBoundingClientRect called");
            return { top: 0, right: 0, bottom: 0, left: 0, width: 0, height: 0 };
        };
    }
};

// Call initialization when document is ready
document.addEventListener('DOMContentLoaded', function() {
    window.initMudBlazor();
});
