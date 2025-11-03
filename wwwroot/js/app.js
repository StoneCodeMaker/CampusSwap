window.blazorCulture = {
    get: () => window.localStorage['BlazorCulture'],
    set: (value) => window.localStorage['BlazorCulture'] = value
};

// Function to set dark mode
window.setDarkMode = function (isDarkMode) {
    try {
        // Add or remove the dark mode class to the document body
        if (isDarkMode) {
            document.body.classList.add('mud-theme-dark');
        } else {
            document.body.classList.remove('mud-theme-dark');
        }
        
        // Store the preference
        window.localStorage['DarkMode'] = isDarkMode;
        
        console.log('Dark mode set to:', isDarkMode);
    } catch (error) {
        console.error('Error setting dark mode:', error);
    }
};

// Initialize dark mode from stored preference
document.addEventListener('DOMContentLoaded', function() {
    try {
        const isDarkMode = window.localStorage['DarkMode'] === 'true';
        window.setDarkMode(isDarkMode);
        console.log('Initialized dark mode from storage:', isDarkMode);
    } catch (error) {
        console.error('Error initializing dark mode:', error);
    }
});
