import React from 'react';

interface AppProps {

}

interface AppState {

}

class App extends React.Component<AppProps, AppState> {

    constructor(props: AppProps) {
        super(props);
    }

    componentDidMount() {

    }

    render() {
        return (
            <div>
                Hello Glossary
            </div>
        );
    }
}

export default App;