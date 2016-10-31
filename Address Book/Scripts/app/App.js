import React, { Component } from 'react';
import { Router, Route, Link, hashHistory, browserHistory } from 'react-router'
import ContactsList from './ContactsList';
import ContactInfo from './ContactInfo';
import ContactForm from './ContactForm'; 



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
        <Route path="/contact/new" component={ContactForm} />
        <Route path="/contact/:id" component={ContactInfo} />
        <Route path="/contact/:id/edit" component={ContactForm} />
      </Router>
    );
  }
}

export default App;