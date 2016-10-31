import React, { Component } from 'react';
import ContactsList from './ContactsList';


class App extends Component {
  render() {

    var dummyContacts = [
      {
        id: 0,
        name: 'Domingo',
        nickName: 'Dom'
      }
    ];

    return (

      <div className="App">

        <ContactsList contacts={dummyContacts}></ContactsList>

        <div className="App-header">
          <h2>Welcome to React</h2>
        </div>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
      </div>
    );
  }
}

export default App;