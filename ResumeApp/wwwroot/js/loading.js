function updateProgress() {
    let progress = getComputedStyle(document.documentElement).getPropertyValue("--blazor-load-percentage");
    if (progress != null && progress != "") {
        progress = progress.replace("%", "")
        progress = Math.floor(parseFloat(progress));
        console.log("Progress: " + progress);
        ui("#app-loading", progress);
    }
    if (progress >= 100) return;
    setTimeout(updateProgress, 100);
}