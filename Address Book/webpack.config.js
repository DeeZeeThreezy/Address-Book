module.exports = {
    entry: './Scripts/app/index.js',
    output: {
        path: './Scripts',
        filename: 'app.bundle.js'
    },
    module: {
        loaders: [{
            test: /\.js$/,
            exclude: /node_modules/,
            loader: 'babel-loader'
        }]
    }
};