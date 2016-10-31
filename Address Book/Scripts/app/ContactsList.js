import React, { Component } from 'react';
import { Link } from 'react-router';
import Contact from './Contact';
import { GetContacts } from './ContactsService';



class ContactsList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            contacts: []
        };
    }

    componentDidMount() {
        GetContacts().done((contacts) => {
            this.setState({
                contacts: contacts
            });
        });
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
            <div>
                <ul>
                    {contactItems}
                </ul>
                <Link to={`/contact/new`}>Add New Contact</Link>
            </div>
        );
    }
}

export default ContactsList;