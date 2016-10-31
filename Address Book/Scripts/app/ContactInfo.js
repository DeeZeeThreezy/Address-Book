import React, { Component } from 'react';
import { Link } from 'react-router';
import { GetContact, DeleteContact } from './ContactsService';

class ContactInfo extends Component {
    constructor(props) {
        super(props);
        this.state = {
            contact: null
        };

        this.delete = this.delete.bind(this);
    }


    delete() {
        DeleteContact(this.state.contact).done(() => {
            alert('Contact deleted');
        });
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
                <h4>Contact: {contact.nickName ? contact.nickName : contact.name}</h4>
                <dl>
                    <dt>Name</dt>
                    <dd>{contact.name}</dd>

                    <dt>Nick Name</dt>
                    <dd>{contact.nickName}</dd>

                    <dt>Birthday</dt>
                    <dd>{contact.birthday}</dd>

                    <dt>Job Title</dt>
                    <dd>{contact.jobTitle}</dd>

                    <dt>Company</dt>
                    <dd>{contact.company}</dd>

                    <dt>Phone Number</dt>
                    <dd>{contact.phoneNumber}</dd>

                    <dt>Email Address</dt>
                    <dd>{contact.emailAddress}</dd>

                    <dt>Address</dt>
                    <dd>{contact.address}</dd>
                </dl>
                <Link to={`/contact/${contact.id}/edit`}>Edit</Link>
                <button type="button" onClick={this.delete}>Delete</button>
            </div>
        );
    }
}

export default ContactInfo;