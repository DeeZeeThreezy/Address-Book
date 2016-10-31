import React, { Component } from 'react';
import Contact from './Contact';


class ContactsList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            contacts: []
        };
    }

    componentDidMount() {

    }

    componentWillUnmount() {

    }

    render() {
        var contacts = this.state.contacts;

        if(!contacts) {
            return (
                <div>Nothing here!</div>
            );
        }
        else if(contacts.length == 0) {
            return (
                <div>No contacts!</div>
            );
        }

        var contactItems = contacts.map(c => (
            <li><Contact key={c.id} contact={c}></Contact></li>
        ));

        return (
            <ul>
                {contactItems}
            </ul>
        );
    }
}

export default ContactsList;