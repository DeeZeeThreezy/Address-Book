import React, { Component } from 'react';
import { Link } from 'react-router';
import { GetContact, DeleteContact } from './ContactsService';

class ContactInfo extends Component {
    constructor(props) {
        super(props);
        this.state = {
            contact: null
        };
    }

    componentDidMount() {
        var contactId = this.props.params.id;
        
        GetContact(contactId).done((contact) => {
            this.setState({
                contact: contact
            });
        });
    }

    componentWillUnmount() {

    }

    delete() {
        DeleteContact(this.state.contact).done(() => {
            alert('Contact deleted');
        });
    }

    render() {
        var contact = this.state.contact;

        if(!contact) {
            return (
                <div>
                    Nothing here!
                    <h4>Contact Info: {this.props.params.id}</h4>
                </div>
            );
        }


        return (
            <div>
                <h4>Contact Info: {contact.id}</h4>
                <h5>{contact.nickName}</h5>
                <p>{contact.name}</p>
                <Link to={`/contact/${contact.id}/edit`}>Edit</Link>
                <button type="button" onClick={this.delete}>Delete</button>
            </div>
        );
    }
}

export default ContactInfo;