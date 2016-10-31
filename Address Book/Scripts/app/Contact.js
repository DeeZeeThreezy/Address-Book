import React, { Component } from 'react';
import { Link } from 'react-router';

class Contact extends Component {
    render() {
        var contact = this.props.contact;

        if(!contact) {
            return (
                <div>Nothing here!</div>
            );
        }


        return (
            <div>
                <Link to={"/contact/" + contact.id}><h3>{contact.nickName ? contact.nickName : contact.name}</h3></Link>
                <p>{contact.name}</p>
            </div>
        );
    }
}

export default Contact;