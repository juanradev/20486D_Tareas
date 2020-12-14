var gulp = require('gulp');

var paths = {
    webroot: "./wwwroot/",
    nodeModules: "./node_modules/"
};

paths.jqueryjs = paths.nodeModules + "jquery/dist/jquery.js";
paths.destinationjsFolder = paths.webroot + "scripts/";

gulp.task("copy-js-file", function () {
    return gulp.src(paths.jqueryjs)
        .pipe(gulp.dest(paths.destinationjsFolder));
});