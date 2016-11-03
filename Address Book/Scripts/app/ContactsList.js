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

        this.deleteCallback = this.deleteCallback.bind(this);
    }

    deleteCallback(deletedContact) {
        this.setState((prevState) => {

            var contactIndex = prevState.contacts.findIndex(c => c == deletedContact);

            prevState.contacts.splice(contactIndex, 1);

            return {
                contacts: prevState.contacts
            };
        });
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
            <div to={`/contact/${c.id}`} key={c.id} className="list-group-item"><Contact contact={c} deleteCallback={this.deleteCallback}></Contact></div>
        ));

        return (
            <div>
                <h3>Contacts</h3>
                <div className="row">
                    <div className="col-md-12">
                        <h3></h3>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12">
                        <div className="list-group">
                            {contactItems}
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12">
                        <Link to={`/contact/new`} className="btn btn-primary" role="button"><i className="glyphicon glyphicon-plus"></i> Add New Contact</Link>
                    </div>
                </div>
            </div>
        );
    }
}

export default ContactsList;