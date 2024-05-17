const path = require('path');
module.exports = {
    mode: 'development',
    entry: './index.tsx',
    resolve: {
        alias: {
            components: path.resolve(__dirname, './components'),
        },
        extensions: ['.js', '.jsx', '.ts', '.tsx'],
    },
    output: {
        path: path.resolve(__dirname, '../Glossary/wwwroot/dist'),
        filename: 'main.js',
    },
    module: {
        rules: [{
            test: /\.js$/,
            use: {
                loader: 'babel-loader',
                options: {
                    presets: ['@babel/preset-react']
                }
            }
        },
        {
            test: /\.css$/i,
            use: ["css-loader"],
        },
        {
            test: /\.tsx?$/,
            use: 'ts-loader',
            exclude: /node_modules/,
        },
        ]
    }
}