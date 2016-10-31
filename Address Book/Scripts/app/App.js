import React, { Component } from 'react';
import { Router, Route, Link, hashHistory, browserHistory } from 'react-router'
import ContactsList from './ContactsList';
import ContactInfo from './ContactInfo';
import ContactEdit from './ContactEdit'; 



// class App extends Component {
//   render() {

//     var dummyContacts = [
//       {
//         id: 0,
//         name: 'Domingo',
//         nickName: 'Dom'
//       }
//     ];

//     return (

//       <div className="App">

//         <ContactsList contacts={dummyContacts}></ContactsList>

//         <div className="App-header">
//           <h2>Welcome to React</h2>
//         </div>
//         <p className="App-intro">
//           To get started, edit <code>src/App.js</code> and save to reload.
//         </p>
//       </div>
//     );
//   }
// }

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
      <Router history={hashHistory}>
        <Route path="/" component={ContactsList} />
        <Route path="/contact/:id" component={ContactInfo} />
        <Route path="/add-contact" component={ContactEdit} />
      </Router>
    );
  }
}

export default App;