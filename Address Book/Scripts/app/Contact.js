import React, { Component } from 'react';
import { Link } from 'react-router';
import { DeleteContact } from './ContactsService';


class Contact extends Component {

    constructor(props) {
        super(props);

        this.delete = this.delete.bind(this);

        this.deleteCallback = props.deleteCallback;
    }

    delete() {
        DeleteContact(this.props.contact).done(() => {
            if(this.deleteCallback) {
                this.deleteCallback(this.props.contact);
            } 
        });
    }

    render() {
        var contact = this.props.contact;

        if(!contact) {
            return (
                <div>Nothing here!</div>
            );
        }


        return (
            <div className="row">
                <div className="col-md-8">
                    <h4><Link to={`/contact/${contact.id}`}>{contact.nickName ? contact.nickName : contact.name}</Link></h4>
                    <p>{contact.name}</p>
                </div>
                <div className="col-md-4">
                    <Link to={`/contact/${contact.id}/edit`} className="btn btn-default" role="button"><i className="glyphicon glyphicon-edit"></i> Edit</Link>
                    <button onClick={this.delete} className="btn btn-danger" type="button"><i className="glyphicon glyphicon-trash"></i> Delete</button>
                </div>
            </div>
        );
    }
}

export default Contact;